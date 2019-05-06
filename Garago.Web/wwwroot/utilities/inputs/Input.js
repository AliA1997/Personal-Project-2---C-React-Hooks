import React from 'react';
import PropTypes from 'prop-types';
import { FormField, TextInput } from 'grommet';
import * as utils from '../utils';
import _ from 'lodash';

const Input = ({type, formType, value, onChange, onKeyPressFunc, propertyName}) => {

    async function onKeyPress(e, type=null) {
        if(type && e.key === 'Enter') 
            await onKeyPressFunc(e, type);
        else if(e.key === 'Enter')
            await onKeyPressFunc(e);
        
        return;
    }
    
    if(type.match(/[(select|suggestions|autocomplete)]gi$/) && type.match(/[(select|suggestions|autocomplete)]gi$/).length)
        return (
            <div>SUggestion Completed</div>
        );
    else 
        if(type === 'password') 
            return (
                <TextInput 
                    className="form-input"
                    type="password"
                    onChange={e => onChange(e, propertyName)}
                    value={value}
                    placeholder="Password"
                    onKeyPress={(e) => formType === 'register' || formType === 'login' ? onKeyPress(e, type) : onKeyPress(e)}
                />
            );
        else 
            return (
                <TextInput 
                    className="form-input"
                    onChange={e => onChange(e, propertyName)}
                    value={value}
                    placeholder="Password"
                    onKeyPress={(e) => formType === 'register' || formType === 'login' ? onKeyPress(e, type) : onKeyPress(e)}
                    placeholder={propertyName === 'displayName' ? 'Display Name' : propertyName}
                />
            );
};

Input.propTypes = {
    type: PropTypes.string.isRequired,
    value: PropTypes.string.isRequired,
    propertyName: PropTypes.string.isRequired,
    onChange: PropTypes.func.isRequired
}

export default Input;