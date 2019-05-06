import React, { useState, useEffect } from 'react';
import { Box } from 'grommet';
import Form from '../../utilities/Form';
import * as utils from '../../utilities/utils';

const createFormObj = utils.initFormObj(['title', 'image',  'price', 'description'])

const CreateProduct = (props) => {

    const [createProductForm, handleChange] = useState(createFormObj);

    function handleFormChange(e, type) {
        
        let form = utils.deepCopy(createProductForm);

        form[type] = e.target.value;
        
        handleChange(form);    
    }

    function resetForm() {
        handleChange({});
    }

    function postProduct(e) {
        
        e.stopPropagation();

        const { garage_sale_id } = props;

        props.createProduct(garage_sale_id, createProductForm);

    }
    // useEffect(() => {


    // }, [garageSaleForm])

    return (
        <Box>
            <Form 
                onChange={handleFormChange} 
                onSubmit={postProduct} 
                onReset={resetForm} 
                fields={['title', 'image',  'price', 'description']} 
                typeOfForm="product"
                isAuth={false} doCreate={true}
            />
        </Box>
    );
};

export default CreateProduct;