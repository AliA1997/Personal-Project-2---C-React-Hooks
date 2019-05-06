import React, { useEffect, useState } from 'react';
import { withRouter } from 'react-router';
import { Box } from 'grommet';
import GarageSaleConsumer from '../../contexts/garageSale/GarageSaleConsumer';
import GarageSaleProvider from '../../contexts/garageSale/GarageSaleProvider';
import DistributionSection from '../../components/DistributionSection';
import * as utils from '../../utilities/utils';
import garageSaleApi from '../../api/GarageSaleApi/garageSaleApi';

const GarageSaleHome = (props) => {

    const [ garageSales, setGarageSales ] = useState([]);

    useEffect(() => {
        
        async function getGarageSales() {
            const garageSaleResult = await garageSaleApi.getGarageSales();
            console.log('garageSaleResult--------', garageSaleResult);
            setGarageSales(garageSaleResult);
        }
        console.log('effect hit----------');
        getGarageSales();
    }, []);
    
    const { history } = props;

    return (
        <React.Fragment>
                <GarageSaleProvider history={history}>
                    <GarageSaleConsumer>
                            
                            {/* Just pass values and it will distribute the values accordingly. */}
                            <DistributionSection type="garage sale" items={garageSales} />
                        
                        </GarageSaleConsumer>
                </GarageSaleProvider>
        </React.Fragment>
    );
};

export default withRouter(GarageSaleHome);