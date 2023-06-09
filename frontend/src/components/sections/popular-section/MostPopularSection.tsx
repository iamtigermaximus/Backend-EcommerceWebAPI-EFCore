import { Box, CardMedia, Typography } from '@mui/material';
import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAppSelector, useAppDispatch } from '../../../hooks/reduxHook';
import { addToCart } from '../../../redux/reducers/cartSlice';
import { fetchAllProducts } from '../../../redux/reducers/productSlice';
import {
  ProdCard,
  ProductCardContent,
  ProductCardButton,
  ProductCardName,
  ProductCardPrice,
} from '../../product-card/ProductCard.styles';
import {
  SectionContainer,
  SectionNameContainer,
  SectionName,
  ProductCardsContainer,
  CardImageContainer,
} from './MostPopularSection.styles';

const MostPopularSection = () => {
  const products = useAppSelector((state) => state.productReducer);
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    dispatch(fetchAllProducts());
  }, [dispatch]);
  return (
    <SectionContainer maxWidth={false}>
      <SectionNameContainer>
        <SectionName variant="h6">Most Popular</SectionName>
      </SectionNameContainer>
      <ProductCardsContainer>
        {products.length > 0 &&
          products.slice(8, 14).map((product) => (
            <ProdCard key={product.id}>
              <CardImageContainer
                onClick={() => navigate(`/category/${product.name}`)}
              >
                <CardMedia component="img" height="200" image={product.image} />
                <Box
                  sx={{
                    position: 'absolute',
                    color: 'white',
                    top: 3,
                    padding: '2px 5px',
                    background: '#32CD32',
                    display: 'flex',
                    justifyContent: 'center',
                    borderRadius: '50px',
                  }}
                >
                  <Typography
                    sx={{
                      fontSize: '10px',
                      textTransform: 'uppercase',
                    }}
                  >
                    {product.categoryName}
                  </Typography>
                </Box>
              </CardImageContainer>
              <ProductCardContent>
                <ProductCardButton
                  variant="outlined"
                  color="inherit"
                  onClick={() => dispatch(addToCart(product))}
                >
                  ADD TO CART
                </ProductCardButton>
                <ProductCardName>{product.name}</ProductCardName>
                <ProductCardPrice>$ {product.price}</ProductCardPrice>
              </ProductCardContent>
            </ProdCard>
          ))}
      </ProductCardsContainer>
    </SectionContainer>
  );
};

export default MostPopularSection;
