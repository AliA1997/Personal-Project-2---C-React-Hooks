import React from 'react';
import { Box, Grid, Image, Paragraph } from 'grommet';
import dateFns from 'date-fns';
import * as utils from '../../utilities/utils';
import * as styleUtils from '../../utilities/styleUtils';
import gsPlaceholder from '../../assets/Garage-Sale-Placeholder-img.jpg';

const GarageSaleItem = (props) => {
    const { id, title, image, createdBy, dateOfSale, location, delay, link, history } = props;

    const indexOfBasis = Math.floor(Math.random() * styleUtils.basisArray.length);

    const indexOfHeight = Math.floor(Math.random() * styleUtils.heightArray.length);

    const linkToRoute = utils.formatLink(createdBy.link);

    return (
        <Box background={{color: "light-3"}} fill={true} flex="grow"
            justify="between" alignSelf="center" align="center" 
            basis={styleUtils.basisArray[indexOfBasis]}
            height={styleUtils.heightArray[indexOfHeight]}   margin="3px"
            pad="xsmall" animation={{type: 'fadeIn', delay: delay, duration: 1000}}
        >
            <Image src={image || 'https://www.tnmagazine.org/wp-content/uploads/2017/09/Placeholder-img.jpg'} onClick={() => history.push(`/garage_sales/${id}`)}
                style={{height: '200px', width: styleUtils.getImageWidth(styleUtils.basisArray[indexOfBasis]), padding: 0, marginTop: styleUtils.getTopMargin(styleUtils.heightArray[indexOfHeight], styleUtils.basisArray[indexOfBasis])}} />
            <Box>
                <Paragraph responsive={true} color="black" as="h3">{title || 'No Title Available'}</Paragraph>
                <Paragraph responsive={true} color="black" as="h3" onClick={() => history.push(linkToRoute)}>{createdBy.displayName}</Paragraph>
                <Paragraph responsive={true} color="black" as="h3">{dateFns.format(new Date(dateOfSale), 'MM/DD/YYYY h:m Z') || ''}</Paragraph>
                {/* <Paragraph as="h3"></Paragraph> */}
                <Paragraph responsive={true} color="black" as="h3">{location || ''}</Paragraph>
            </Box>
        </Box>
    );
};

export default GarageSaleItem;