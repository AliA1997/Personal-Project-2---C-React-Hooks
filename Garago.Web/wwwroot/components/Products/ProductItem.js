import React from 'react';
import { Box, Carousel, Heading,  Paragraph, Image, Grid } from 'grommet';
import * as styleUtils from '../../utilities/styleUtils';

const ProductItem = ({image, title, price, location, delay}) => {
    const indexOfBasis = Math.floor(Math.random() * styleUtils.basisArray.length);
    const indexOfHeight = Math.floor(Math.random() * styleUtils.heightArray.length);

    return (
        <Box background={{color: "light-3"}} fill={true} flex="grow"
            justify="start" alignSelf="center" align="center" 
            basis={styleUtils.basisArray[indexOfBasis]}
            height={styleUtils.heightArray[indexOfHeight]}   margin="3px"
            pad="xsmall" animation={{type: 'fadeIn', delay: delay, duration: 1000}}>

            <Image src={image} style={{height: '200px', width: '100%'}} />
            <Paragraph color="black" responsive={true}>{title}</Paragraph>
            <Paragraph responsive={true}>{price}</Paragraph>
            <Paragraph responsive={true}>{location}</Paragraph>
        
        </Box>
    );
}

export default ProductItem;