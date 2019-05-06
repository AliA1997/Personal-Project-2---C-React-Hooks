import React, { useEffect, useState } from 'react';
import { withRouter } from 'react-router';
import { Box, Heading, Image, Title, Location, Paragraph, Carousel } from 'grommet';
import DistributionSection from '../../components/DistributionSection';
import garageSaleApi from '../../api/GarageSaleApi/garageSaleApi';
import productApi from '../../api/ProductApi/productApi';

const GarageSale = (props) => {
    const [garageSale, setGarageSale] = useState({});

    const [products, setProducts] = useState([]);
    
    const { setLocation, match } = props;

    const { id } = match.params;
    
    useEffect(() => {
        
        async function getProducts() {
            const productsResult = await productApi.getProducts(id);
            console.log('productsResult--------------', productsResult);
            setProducts(productsResult);
        }
        
        async function getGarageSale() {
            const garageSaleResult = await garageSaleApi.getGarageSale(id);
            console.log('garageSaleResult------------', garageSaleResult);
            setGarageSale(garageSale);
        }

        navigator.geolocation.getCurrentPosition((position) => {
            const crds = position.coords;
            console.log(crds.latitude);
            console.log(crds.longitude);
            console.log(crds);
        });

    
        getGarageSale();
        getProducts();

    }, {})


    const title = 'Sample Title',
        description = 'Sample Description';
    return (
        <Box>
            <Box
                justify="center"
                alignSelf="center"
            >
                <Carousel play={10000}>
                    <Image src="https://imgplaceholder.com/420x320/ff7f7f/333333/fa-image" id="garage-sale-carousel-image"/>
                    <Image src="http://demo.warptheme.com/images/placeholder_600x400_2.svg" id="garage-sale-carousel-image" />
                    <Image src="https://www.savt.ca/scripts/templates/iDea/images/blog-1.jpg" id="garage-sale-carousel-image" />
                </Carousel>
                <Heading truncate={true} id="garage-sale-title">{title}</Heading>
                <Heading truncate={true} id="garage-sale-subtitle">Description: </Heading>
                <Box 
                    border={{color: 'gray'}}
                >
                    <Paragraph margin="none">{description}</Paragraph>
                </Box>
            </Box>
            {/**Just pass values and it will distribute the values accordingly */}
            
            <DistributionSection type="product" items={[
                        { value: 50, product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 50, product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 50, product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 75, product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 75,  product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 75,  product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 75,  product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 75,  product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 100,  product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 50,  product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 50,  product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 50,  product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                        { value: 75,  product: {title: 'Product TItle', image: 'https://vacanegra.com/wp-content/plugins/widgetkit/assets/images/content-placeholder.svg', createdBy: new Date().getDate(), dateOfSale: new Date().getDate(), location: 'Tallahassee, FL'} },
                    ]} 
            />
        </Box>
    );
};

export default withRouter(GarageSale);