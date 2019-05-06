import React from 'react';
import { Box } from 'grommet';
import GarageSaleItem from './GarageSale/GarageSaleItem';
import ProductItem from './Products/ProductItem';
import _ from 'lodash';
import UserItem from './User/UserItem';

const DistributionSection = ({type, items, history}) => {
    console.log('history---------------', history)
    return (
        <div id="distribution-container">
            {
                items.map((item, i) => {
                    
                    const delay = Math.random() * 20;
                    
                    if(type === 'product') 
                        return <ProductItem key={item.id || i} {...item} delay={delay * 100} history={history} />
                    else if(type === 'users')
                        return <UserItem key={item.id || i} {...item} delay={delay * 100} history={history} />
                    else 
                        return <GarageSaleItem key={item.id || i} {...item} delay={delay * 100} history={history} />
                    // return <GarageSaleItem key={item.id || i} {...item} delay={delay * 100} />
                })
            }
        </div>
    );
};

export default DistributionSection;