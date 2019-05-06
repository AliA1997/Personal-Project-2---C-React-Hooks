import React, { useState, useEffect } from 'react';
import { Box } from 'grommet';
import Form from '../../utilities/Form';
import * as utils from '../../utilities/utils';

const createFormObj = utils.initFormObj(['title', 'adImage', 'description'])

const CreateGarageSale = (props) => {
    const [garageSaleForm, handleChange] = useState(createFormObj);

    function handleFormChange(e, type) {
        
        let form = utils.deepCopy(garageSaleForm);

        form[type] = e.target.value;
        
        handleChange(form);    
    }

    function resetForm() {
        handleChange({});
    }

    function postGarageSale() {
        props.createGarageSale();
    }
    // useEffect(() => {


    // }, [garageSaleForm])

    return (
        <Box>
            <Form 
                onChange={handleFormChange} 
                onSubmit={postGarageSale} 
                onReset={resetForm} 
                fields={['title', 'adImage', 'description']} 
                typeOfForm="garage-sale"
                isAuth={false} doCreate={true}
            />
        </Box>
    );
};

export default CreateGarageSale;