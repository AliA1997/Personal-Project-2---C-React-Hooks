import React, { useState, useContext } from 'react';
//import your logo.
import GaragoLogo from '../assets/Garago-Logo.svg';
// import { SubMenu, MenuItemGroup, Menu, Icon, Typography } from 'antd';
import { Box, Image} from 'grommet';
//import your AuthContext to be used with React useContext hook.
import AuthConsumer from '../contexts/auth/AuthConsumer';
import AuthModal from '../components/User/AuthModal';
import { Shop, User, UserSettings, Login, Logout } from 'grommet-icons';
import * as utils from '../utilities/utils';
// import 'antd/lib/sub-menu/style/css';

const Navbar = (props) => {

    const { selectedItem, currentUser, handleShowModal } = props;


    function handleClick(e, type) {
        props.selectItem(e, type);
        if(type === 'login')
            handleShowModal(true, type);
        else if(type === 'sign_up')
            handleShowModal(true, type);
        else if(type === 'logout')
            authValue.logoutUser(e);
        else if(type === 'home') 
            props.history.push('/');
        else 
            props.history.push(`/${type}`);
    };


    return (
        <Box
            direction="row"
            color="brand"
            background="brand"
            justify="end"
            align="end"
            pad="medium"
            gap="large"
            className="main-nav"
        >
            {/**Auth Modal Section------------ */}
            <AuthConsumer>
                <AuthModal />
            </AuthConsumer>
            <Image 
                src={GaragoLogo}
                alignSelf="center"
                basis="small"
                margin={{right: '250px'}}
                id="logo"
                onClick={e => handleClick(e, 'home')}
            />
            <Box 
                direction="row"
                basis="small"
                justify="around"  
                pad="small"
                round={true}
                onClick={e => handleClick(e, 'users')}
                className={selectedItem === 'users'  ? "active nav-item" : "nav-item"}
            >
                <User size="medium" color={selectedItem === "users" ? "brand" : "white"}/>
                Users
            </Box>

            <Box 
                direction="row"
                basis="small"
                justify="around"  
                pad="small"
                round={true}
                onClick={e => handleClick(e, 'garage_sales')}
                className={selectedItem == 'garage_sales' ? "active nav-item" : "nav-item"}
            >
                <Shop size="medium" color={selectedItem === "garage_sales" ? "brand" : "white"}/>
                Garage Sales
            </Box>

 
            {
                currentUser && currentUser != {} ? 
                    (
                        <React.Fragment>
                            <Box
                                direction="row"
                                basis="small" 
                                justify="around"  
                                pad="small"
                                round={true}
                                onClick={e => handleClick(e, 'logout')}
                                className={selectedItem == 'logout' ? "active nav-item" : "nav-item"}
                            >
                                <Logout size="medium" color={selectedItem === "logout" ? "brand" : "white"}/>
                                Logout
                            </Box>
                            <Box
                                direction="row"
                                basis="small" 
                                justify="around"  
                                pad="small"
                                round={true}
                                onClick={e => handleClick(e, 'my_account')}
                                className={selectedItem == 'my_account' ? "active nav-item" : "nav-item"}
                            >
                                <UserSettings size="medium" color={selectedItem === "my_account" ? "brand" : "white"}/>
                                My Account
                            </Box>
                        </React.Fragment>
                    )
                    : 
                    (
                        <React.Fragment>
                            <Box
                                direction="row"
                                basis="small" 
                                justify="around"  
                                pad="small"
                                round={true}
                                onClick={e => handleClick(e, 'login')}
                                className={selectedItem == 'login' ? "active nav-item" : "nav-item"}
                            >
                                <Login size="medium" color={selectedItem === "login" ? "brand" : "white"}/>
                                Login
                            </Box>

                            <Box
                                direction="row"
                                basis="small" 
                                justify="around"  
                                pad="small"
                                round={true}
                                margin={{left: '50px'}}
                                onClick={e => handleClick(e, 'sign_up')}
                                className={selectedItem == 'sign_up' ? "active nav-item" : "nav-item"}
                            >
                                Sign Up
                            </Box>
                        </React.Fragment>
                    )
            }
            
        </Box>
    );
};

export default Navbar;