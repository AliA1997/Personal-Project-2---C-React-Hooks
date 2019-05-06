import React, { useEffect, useState } from 'react';
import { withRouter } from 'react-router';
import usersApi from '../../api/UsersApi/usersApi';
import UserProvider from '../../contexts/users/UserProvider';
import UserConsumer from '../../contexts/users/UserConsumer';
import { Box, Heading, Image, Paragraph } from 'grommet';
import dateFns from 'date-fns';

const UserPage = (props) => {

    const [ user, setUser ] = useState({});

    const { match } = props;

    const { id } = match.params;

    useEffect(() => {

        async function getUser() {
            const userResult = await usersApi.getUser(id);
            setUser(userResult);
        }
        
        getUser();

    }, {});

    return (
        <UserProvider>
           <UserConsumer>
                <React.Fragment>
                    <Box style={{marginLeft: 'auto', marginRight: 'auto', width: '80%'}}>
                        <Heading>{user.displayName}</Heading>
                        <Image src={user.avatar}  style={{width: '40%', height: '500px'}}/>
                        {/**Add functionality such as adding friend and social media link. */}
                        <Box>
                            <Paragraph>Registered At {dateFns.format(user.createdAt, 'MM/DD/YYYY')}</Paragraph>

                        </Box>
                        <Paragraph>{user.name}</Paragraph>
                    </Box>
                </React.Fragment>
           </UserConsumer>
        </UserProvider>
    );
};

export default withRouter(UserPage);