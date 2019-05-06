import * as AjaxCallCreators from '../AjaxCallCreators';
import * as config from '../../utilities/config';

const homeApi = `${config.apiUrl}/home/products`;

export default {
    
    getProducts: function() {
        return AjaxCallCreators.get(homeApi, null, null, 'accessToken');
    },

    getProduct: function(id) {
        return AjaxCallCreators.get(`${homeApi}/${id}`, null, null, null);
    }
    
};