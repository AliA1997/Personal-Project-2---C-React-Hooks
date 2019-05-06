import * as AjaxCallCreators from '../AjaxCallCreators';
import * as config from '../../utilities/config';

const garageSaleApi = `${config.apiUrl}/garage_sales`;

export default {
            
    //Return a promise from each api method similar to a service in angular1.
    getGarageSales: function() {
        return AjaxCallCreators.get(garageSaleApi, null, null, 'accessToken');
    },

    getGarageSale: function(id) {
        return AjaxCallCreators.get(`${garageSaleApi}/${id}`, null, null, null);
    }
          
}