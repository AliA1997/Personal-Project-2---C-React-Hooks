import React from 'react';
import { Box, Paragraph, Heading, Image } from 'grommet';
import * as styleUtils from '../../utilities/styleUtils';
import dateFns from 'date-fns';

const UserItem = ({displayName, avatar, createdAt, link}) => {
    
    const indexOfBasis = Math.floor(Math.random() * styleUtils.basisArray.length);

    const indexOfHeight = Math.floor(Math.random() * styleUtils.heightArray.length);

    return (
        <Box
            basis={styleUtils.basisArray[indexOfBasis]}
            height={styleUtils.heightArray[indexOfHeight]} 
        >
            <Image src={avatar} />
            <Heading>{displayName}</Heading>
            <Paragraph>Registered at: {dateFns.format(createdAt, 'MM/DD/YYYY')}</Paragraph>
        </Box>
    );
};

export default UserItem;