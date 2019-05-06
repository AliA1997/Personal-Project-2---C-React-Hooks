import * as AjaxCallCreators from '../AjaxCallCreators';
import * as config from '../../utilities/config';

const userApi = `${config.apiUrl}/users`;

export default {
    
    getUsers: function() {
        return AjaxCallCreators.get(userApi, null, null, 'accessToken');
    },

    getUser: function(id) {
        return AjaxCallCreators.get(`${userApi}/${id}`, null, null, null);
    }
    
};