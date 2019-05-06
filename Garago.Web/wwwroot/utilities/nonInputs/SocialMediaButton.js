import React from 'react';
import PropTypes from 'prop-types';
import { Button } from 'grommet';
import { Facebook, GooglePlus, Twitter } from 'grommet-icons';

const SocialMediaButton = ({type, onClick}) => {
    if(type === 'facebook')
        return (
            <Button 
                className='social-media-button'
                icon={<Facebook size="medium" color="light-1"/>}
                style={{backgroundColor: "#3b5998", borderRadius: 0, color: "white"}}
                color="light-5"
                label='Login with Facebook' 
                onClick={onClick}
            />
        );
    else if(type === 'google')
        return (
            <Button 
                className='social-media-button'
                icon={<GooglePlus size="medium" color="#DB4437" style={{marginRight: '10px'}}/>}
                style={{backgroundColor: 'light-1', borderRadius: 0}}
                color="light-5"
                label='Login with Google'
                onClick={() => handleShowModal(false, selectedItem)}
            />
        );
    else if(type === 'twitter')
        return (
            <Button 
                className='social-media-button'
                icon={<Twitter size="medium" color="light-1"/>}
                style={{backgroundColor: '#1DA1F2', borderRadius: 0, color: "white"}}
                color="light-5"
                label='Login with Twitter' 
                onClick={() => handleShowModal(false, selectedItem)}
            />
        );
};

SocialMediaButton.propTypes = {
    type: PropTypes.string.isRequired,
    onClick: PropTypes.func.isRequired
}

export default SocialMediaButton;
