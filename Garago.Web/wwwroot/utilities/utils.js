import _ from 'lodash';


export const formatLink = (link) => {
    if(process.env._DEV_) 
        return link.slice(21, link.length);
    else 
        return link.slice(22, link.length);
}

export const inputRegularExpressions = (type) => {
    let validationToReturn;
    switch(type) {
        //The regular expression for the password must contains letter and must have 6 characters and no more than 15. NO characters other than underscore, letters, and numbers.
        case 'password': 
            validationToReturn = {
                            regexp: new RegExp(/^[a-zA-Z]\w{5,14}$/),
                            message: `Please put a valid password.`
                        };
            break;
        //Basic regular expression for email vaildation
        case 'email':
            validationToReturn = {
                            regexp: new RegExp(/[\w-]+@([\w-]+\.)+[\w-]+/),
                            message: `Please put a valid email.`  
                    };
            break;
        default:
            validationToReturn = {
                regexp: new RegExp(/[\w-]+@([\w-]+\.)+[\w-]+/),
                message: 'type-----' 
            };
    };
    return validationToReturn;
}

export function deepCopy(obj) {
    let newObj = {};
    const keys = Object.keys(obj); 
    
    for(let i = 0; i < keys.length; i++) {
        
        if(typeof newObj[keys[i]] === 'object')
            newObj[keys[i]] = deepCopy(obj[keys[i]]);
        else 
            newObj[keys[i]] = obj[keys[i]]
    
    }

    return newObj;
}

//Define a function that will set the document of the title to the argument passed in.
export function setDocTItle(titleArg, containsAppTitle) {
    if(containsAppTitle === false)
        document.title = 'Garago - ' + titleArg;
    else
        document.title = titleArg;
}

//Define a method that will be used to create initial Form object other than logging in.
export function initFormObj(objFields) {
    let objToReturn = {};
    
    objFields.forEach(field => {
        objToReturn[field] = '';
    });

    return objToReturn;
}

