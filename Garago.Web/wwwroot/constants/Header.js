import React from 'react';
import PropTypes from 'prop-types';
import { Box, Heading } from 'grommet';

const Header = ({title, icon}) => {
    return (
        <Box responsive={true} height="medium" width="medium">
            {
                icon ? 
                ''
                : ''
            }
            <Heading responsive={true}>{title}</Heading>
        </Box>
    );
};

Header.propTypes = {
    title: PropTypes.string.isRequired,
    icon: PropTypes.string
};

export default Header;