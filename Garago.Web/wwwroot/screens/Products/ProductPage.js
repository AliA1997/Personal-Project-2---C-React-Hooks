import React, { useState, useEffect } from 'react';
import { Box, Carousel, Grid, Image, Text} from 'grommet';
import dateFns from 'date-fns';
import productsApi from '../../api/ProductApi/productApi';

const ProductPage = (props) => {
    const [product, setProduct] = useState([]);
    
    const { id } = props.match.params('id');

    useEffect(() => {
        async function getProduct() {
            const productResult = await productsApi.getProduct(id);
            console.log('productResult-------------', productResult);
            setProduct(productResult);
        }

        getProduct();
    })

    const created_date = dateFns.format(new Date(product.createdAt), 'MM/DD/YYYY');
    return (
        <Grid
        rows={["small", "medium", "small"]}
        columns={["xxsmall", "small", "small"]}
        gap="medium"
        areas={[
            { name: 'header', start: [0, 0], end:[1, 0] },
            { name: 'product-carousel', start: [0, 1], end: [2, 1] },
            { name: 'description', start: [2, 2], end: [2, 2] }
        ]}
        >
            {/* The areas props for the Grid have array of objects each contain a name property, and have a item using the area property referencing that specific object.*/}
            <Box gridArea="header" background="black">
                <Text as="h2">{product.title || ''}</Text>
            </Box>
            <Carousel gridArea="product-carousel">
                <Image src={product.image || ''} class="carousel-item" />
            </Carousel>
            <Box gridArea="description">
                <Text>{product.description || ''}</Text>
                <Text>{created_date}</Text>
            </Box>
        </Grid>
    );
};

export default ProductPage;