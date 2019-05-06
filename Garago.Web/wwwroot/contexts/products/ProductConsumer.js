import React from 'react';
import { ProductContext } from './ProductProvider';

const ProductConsumer = (props) => {
    return (
        <ProductContext.Consumer>
            {context => {
                return React.Children.map(props.children, child => {
                    return React.cloneElement(child, context);
                })
            }}
        </ProductContext.Consumer>
    );
};

export default ProductConsumer;