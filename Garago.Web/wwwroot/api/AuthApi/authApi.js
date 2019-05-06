import * as AjaxCallCreators from '../AjaxCallCreators';
import * as config from '../../utilities/config';

const authApi = `${config.apiUrl}/account`;

export default {

    login: function(loginForm) {
        return AjaxCallCreators.post(`${authApi}/login`, null, loginForm, 'accessToken');
    },
    
    loginFacebook: function(authResponse) {
        return AjaxCallCreators.post(`${authApi}/facebook`, ['/me'], authResponse, authResponse.accessToken)
    },
    
    logout: function() {
        return AjaxCallCreators.post(`${authApi}/logout`, null, null, 'accessToken-logout');
    },

    register: function(registerForm) {
        return AjaxCallCreators.post(`${authApi}/register`, null, registerForm, 'accessToken');
    }

}