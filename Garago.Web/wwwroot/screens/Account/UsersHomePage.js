import React, { useState, useEffect } from 'react';
import usersApi from '../../api/UsersApi/usersApi';
import DistributionSection from '../../components/DistributionSection';
import { Box, Heading } from 'grommet';

const UsersHomePage = (props) => {

    const [users, setUsers] = useState([]);

    useEffect(() => {
        
        async function getUsers() {
            const userResult = await usersApi.getUsers();
            console.log('userResult-----------', userResult);
            setUsers(userResult);
        }

        getUsers();
    }, []);

    return (
        <Box>
            <Heading>Search Users</Heading>
            <DistributionSection type="users" items={users} />
        </Box>
    );
};

export default UsersHomePage;