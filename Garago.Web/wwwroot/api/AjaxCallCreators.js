// import * as ajaxUtils from '../utilities/ajaxUtils';
import * as ajaxUtils from '../utilities/ajaxUtils';

const email = 'aalhaddad1997@gmail.com';
//Each request will accept a access token, url, formData, params,
export function get(url, params, formData, accessToken) {
    //Each request will return a generice promise that will return the fetch api, and based on it's status code will reject or resolve the value.
    return new Promise((resolve, reject) => {
        
        if(params) {
            const paramKeys = Object.keys(params);
            //Map over keys which will return a new array with each key being convert into a encodedURICOmponent that will generate a key, value pair
            const query = paramKeys.map(key => encodeURIComponent(key) + '=' + encodeURIComponent(param[key])).join('&');
            url = url + '?' + query;
        }

        fetch(new Request(url,
            {
                credentials: 'include',
                method: 'GET',
                // type: ajaxUtils.defaultMediaType,
                headers: {
                    'Authorization': 'Bearer ' + accessToken,
                    credentials: 'same-origin'
                },
                // mode: 'cors',
                mode: 'cors'
            })  
        )
        .then(response => {
            console.log('ajaxCallCreators response---------', response);
            switch(response.status) {
                case ajaxUtils.statusCodes.ok:
                    response.json().then(data => {
                        resolve(data);
                    });
                    break;

                case ajaxUtils.statusCodes.created:
                    response.text().then(data => {
                        resolve();
                    });
                    break;

                case ajaxUtils.statusCodes.badRequest:
                    reject(`Bad request try again or contact customer support at ${email}.`)
                    break;

                case ajaxUtils.statusCodes.notAuthorized:
                    reject('Not authorized to retrieve data for this page.');
                    break;

                case ajaxUtils.statusCodes.notAllowed:
                    reject('Not allowed to access page.');
                    break;
                
                case ajaxUtils.statusCodes.notValidOutput:
                    reject('Error not a valid output.');
                    break;

                case ajaxUtils.statusCodes.serverError:
                    reject(`Error try again or contact customer support at ${email}.`);
                    break;      

                default: 
                    reject("Unknown response code " + response.status);
                    break;
            }
        })

    })
}


//Each request will access a accessToken, url, params, formData, and a accessToken
export function post(url, params, formData, accessToken) {
    
    //If the params is not null 
    if(params) {
        //Then get the keys from the params.
        const paramKeys = Object.keys(params);
        //Now map over keys and define your query.
        //Then define your query using the encodeUriComponent to define your key value pairs for your query strings.
        const query = paramKeys.map(key => encodeURIComponent(key) + '=' + encodeURIComponent(params[key])).join('&');
        //Then reassign your url to your results.
        url = url + '?' + query;
    }
    
    //Each request will return a generic Promise will return the fetch api, and based on it's status code will reject ro resolve the promise.
    return new Promise((resolve, reject) => {
        
        //Use fetch api and the request obejct to define a Request.
        //YOur reuqest will require a url, credentials, headers, and the mode.
        fetch(new Request(url, 
            {
                credentials: 'include',
                method: 'POST',
                body: JSON.stringify(formData),
                type: ajaxUtils.defaultMediaType,
                headers: {
                    //Pass your authorization header, content type and credentials.
                    'Content-Type': ajaxUtils.defaultMediaType,
                    'Authorization': 'Bearer ' + accessToken,
                    credentials: 'same-origin',
                },
                //set it's mode to cors.
                mode: 'cors'
            }))
            //Resolve the promise, and provide a switch statement based on the response status.
        .then(response => {
            console.log('ajaxCallCreators Post response-----------', response);
            switch(response.status) {
                //If the status code is 200 then resolve the data.
                case ajaxUtils.statusCodes.ok:
                    response.json().then(data => {
                        resolve(data);
                    });
                    break;
                //If the a new item is 201 
                case ajaxUtils.statusCodes.created:
                    response.json().then(data => {
                        resolve(data);
                    });
                    break;
                //If there is no content primarily for logging out, and deleting, and updating fields.
                case ajaxUtils.statusCodes.noContent:
                    response.text().then(data => {
                        resolve();
                    })
                //If it is a bad request 400
                case ajaxUtils.statusCodes.badRequest:
                    reject(`Bad request try again or contact customer support at ${email}.`)
                    break;
                //If it is not authorized 401 
                case ajaxUtils.statusCodes.notAuthorized:
                    reject('Not authorized to retrieve data for this page.');
                    break;

                case ajaxUtils.statusCodes.notAllowed:
                    reject('Not allowed to access page.');
                    break;
                
                case ajaxUtils.statusCodes.notValidOutput:
                    reject('Error not a valid output.');
                    break;

                case ajaxUtils.statusCodes.serverError:
                    reject(`Error try again or contact customer support at ${email}.`);
                    break;      

                default: 
                    reject("Unknown response code " + response.status);
                    break;
            }
        })

    })
}

export function patch(url, params, formData, accessToken) {
    
}

export function put(url, params, formData, accessToken) {
    
}

// export function delete(url, params, formData, accessToken) {
    
// }

