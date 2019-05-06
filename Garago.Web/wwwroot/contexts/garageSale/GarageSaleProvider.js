import React from 'react';
import * as utils from '../../utilities/utils';
import garageSaleApi from '../../api/GarageSaleApi/garageSaleApi';
import { popup } from 'grommet';

//Define your initialState for your garageSale context.
const initialState = {
    createdGarageSale: {},
    currentLocation: {},
}

//Export your GarageSaleCOntext to be used later
export const GarageSaleContext = React.createContext(initialState);

export default class GarageSaleProvider extends React.Component {

    state = initialState;

    createGarageSale = async (newGarageSale) => {
        const createdGarageSale = await garageSaleApi.createGarageSale(newGarageSale);
        this.setState({ createdGarageSale });
    }

    updateGarageSale = async (garageSaleId, updatedGarageSale) => {
        const message = await garageSaleApi.updateGarageSale(garageSaleId, updatedGarageSale);
        
    }
    
    render() {
        //As your value for your Provider will be your state nad your history prop.
        return (
            <GarageSaleContext.Provider
                value={{
                    ...this.state,
                    history: this.props.history,
                    createGarageSale: this.createGarageSale,
                    updateGarageSale: this.updateGarageSale
                }}
            >
                {/**Render the children of the provider */}
                {this.props.children}
            </GarageSaleContext.Provider>        
        );
    }
}