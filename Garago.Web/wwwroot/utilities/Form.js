import React from 'react';
import Input from './inputs/Input';
import { Form, Button, Heading } from 'grommet';
import _ from 'lodash';
import PropTypes from 'prop-types';

const GaragoForm = ({onChange, onSubmit, onReset, fields, typeOfForm, isAuth, doCreate}) => {
    console.log('fields-------------', fields);
    return (
        <Form onSubmit={e => typeOfForm === 'register' || typeOfForm === 'login' ? onSubmit(e, typeOfForm) : onSubmit(e)}
              onReset={e => onReset(e)} className="login-form">
            {fields.map((field, i) => {
                console.log('field----------', field);
                return <Input key={i} {...field} onChange={e => onChange(e, field.type)} onSubmit={onSubmit} formType={typeOfForm} />
            }
            )}
            <Button type="submit" primary className='submit-button'
                label={!isAuth ?
                            doCreate ?
                                `Create ${_.capitalize(typeOfForm)}` 
                                : `Update ${_.capitalize(typeOfForm)}`
                            : _.capitalize(typeOfForm)}
                hoverIndicator={true}
            />
        </Form>
    );
};

GaragoForm.propTypes = {
    onChange: PropTypes.func.isRequired,
    onSubmit: PropTypes.func.isRequired,
    onReset: PropTypes.func,
    fields: PropTypes.arrayOf(PropTypes.object.isRequired).isRequired,
    typeOfForm: PropTypes.string.isRequired,
    isAuth: PropTypes.bool.isRequired,
    doCreate: PropTypes.bool.isRequired
};

export default GaragoForm;