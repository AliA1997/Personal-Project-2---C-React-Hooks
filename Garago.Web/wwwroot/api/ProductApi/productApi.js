import * as AjaxCallCreators from '../AjaxCallCreators';
import * as config from '../../utilities/config';

const productApi = (garageSaleId) => `${config.apiUrl}/garage_sales/${garageSaleId}/products`;

export default {
    getProducts: function(garageSaleId) {

        const productUrl = productApi(garageSaleId);
        
        console.log('productUrl---------', productUrl);

        return AjaxCallCreators.get(productUrl, null, null, null)
                .then(res => {
                    return res;
                });
    },
    
    getProduct: function(garageSaleId, id) {

        const productUrl = productApi(garageSaleId);

        return AjaxCallCreators.get(`${productUrl}/${id}`, null, null, null)
                .then(res => {
                    return res;
                });
    }
}
