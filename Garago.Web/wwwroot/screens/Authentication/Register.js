import React, { useEffect, useState } from 'react';
import { Box, Heading } from 'grommet';
import GaragoForm from '../../utilities/Form';

const RegisterForm = (props) => {
    const { handleRegisterChange, register, registerForm } = props;
    return (
        <Box margin={{top: '50px'}} style={{marginLeft: 'auto', marginRight: 'auto'}}>
            <Heading style={{marginBottom: '50px'}} >Register</Heading>
            <GaragoForm onChange={handleRegisterChange} onSubmit={register} onReset={() => console.log('reset----------')} fields={[

                                                                                                                {
                                                                                                                    type: 'avatar', 
                                                                                                                    propertyName: 'avatar',                                                                                     
                                                                                                                    value: registerForm['avatar']
                                                                                                                },
                                                                                                                {
                                                                                                                    type: 'name',
                                                                                                                    propertyName: 'name',
                                                                                                                    value: registerForm['name']
                                                                                                                },
                                                                                                                {
                                                                                                                    type: 'displayName',
                                                                                                                    propertyName: 'displayName',
                                                                                                                    value: registerForm['displayName']
                                                                                                                },
                                                                                                                {
                                                                                                                    type: 'password', 
                                                                                                                    propertyName: 'password',                                                                                     
                                                                                                                    value: registerForm['password']
                                                                                                                }

                                                                                                            ]} typeOfForm="login" isAuth={true} doCreate={false}/>
        </Box>
    );
};

export default RegisterForm;