import React, { Component } from 'react';
import productApi from '../../api/ProductApi/productApi';

const initialState = {
    createdProduct: {},
    currentLocation: {}
};

export const ProductContext = React.createContext(initialState);

export default class ProductProvider extends Component {

    state = initialState;

    createProduct = async (garageSaleId, productToCreate) => {

        const createdProduct = await productApi.createProduct(garageSaleId, productToCreate);
        
        this.setState({ createdProduct });

        //Toast createdProducts
    
    }

    updateProduct = async (garageSaleId, productId, updatedProduct) => {
        
        const message = await productApi.updateProduct(garageSaleId, productId, updatedProduct);

        //Toast message
    }

    render() {
        return (
            <ProductContext.Provider
                value={{
                    ...this.state,
                    createProduct: this.createProduct
                }}
            >
                {this.props.children}
            </ProductContext.Provider>
        );
    }
}