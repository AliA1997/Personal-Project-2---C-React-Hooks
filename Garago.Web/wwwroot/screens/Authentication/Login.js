import React from 'react';
import { Box, Heading } from 'grommet';
import GaragoForm from '../../utilities/Form';

const Login = (props) => {
    const { loginUser, handleLoginChange, authForm } = props;
    console.log('props---------', props);
    return (
        <Box margin={{top: '50px'}} style={{marginLeft: 'auto', marginRight: 'auto'}}>
            <Heading style={{marginBottom: '50px'}} >Login</Heading>
            <GaragoForm onChange={handleLoginChange} onSubmit={loginUser} onReset={() => console.log('reset----------')} fields={[
                                                                                                                {
                                                                                                                    type: 'displayName',
                                                                                                                    propertyName: 'displayName',
                                                                                                                    value: authForm['displayName']
                                                                                                                },
                                                                                                                {
                                                                                                                    type: 'password', 
                                                                                                                    propertyName: 'password',                                                                                     
                                                                                                                    value: authForm['password']
                                                                                                                }
                                                                                                            ]} typeOfForm="login" isAuth={true} doCreate={false}/>
        </Box>
    );
};

export default Login;