import React, { useState, useEffect } from 'react';
import { Box, Image, Text } from 'grommet';
import homeApi from '../api/ProductApi/homeProductsApi';
import DistributionSection from '../components/DistributionSection';
// import ProductPage  from '../screens/Products/ProductPage';
// import ProductItem from '../components/ProductItem';

const Home = (props) => {
    const [items, setItems] = useState([]);

    useEffect(() => {
        async function getRandomProducts() {
            
            // const products = await homeApi.getProducts();
            
            // console.log('products----------', products);

            // setItems(products);

        
        }
        // getRandomProducts();
    }, [])
    return (
        <Box 
            direction="column"
            color="brand"
            justify="center"
            gap="large"
        >
            <Box
                direction="row"
                justify="between"
                basis="medium"
                pad="large"
                className="pane"
                id="first-pane"
            >
            </Box>
                <Text color="white" size="xlarge">Register, then look for sales near by.</Text>

            <Box
                direction="row"
                justify="between"
                basis="medium"
                className="pane"
            >
                <DistributionSection
                    type="garage sale"
                    items={items} 
                />
            </Box>
        </Box> 
    );
};

export default Home;