import * as Roles from './Roles';
import Home from '../screens/Home';
//Garage Sale Pages
import GarageSaleHome from '../screens/GarageSale/GarageSaleHome';
import GarageSale from '../screens/GarageSale/GarageSale';
import GarageSaleSettingsTab from '../screens/GarageSale/GarageSaleSettingsTab';
import CreateGarageSale from '../screens/GarageSale/CreateGarageSale';
import GarageSaleReviews from '../screens/Reviews/GarageSaleReviews';
import GarageSaleSoldHistoryTab from '../screens/GarageSale/GarageSaleSoldHistoryTab';
import GarageSaleDeleteHistoryTab from '../screens/GarageSale/GarageSaleDeleteHistoryTab';
import GarageSalesReserveProductsTab from '../screens/GarageSale/GarageSalesReserveProductsTab.js';
////////////////////////////////////////////////////////////
import UsersHomePage from '../screens/Account/UsersHomePage';
import UserPage from  '../screens/Account/UserPage';
import Login from '../screens/Authentication/Login';
import Register from '../screens/Authentication/Register';
//Product Pages
import CreateProduct from '../screens/Products/CreateProduct';
import ProductSearch from '../screens/Products/ProductSearch';
import ProductPage from '../screens/Products/ProductPage';
import ProductSettings from '../screens/Products/ProductSettings';
/////////////////////////////////////////////////////////////////////
////Account Pages.
import SettingsTab from '../screens/Account/SettingsTab';
import EditAccountTab from '../screens/Account/EditAccountTab';
import MyCartTab from '../screens/Account/MyCartTab';
////////////////
///Shipper Pages
import OrdersTab from '../screens/Shipper/OrdersTab';
import OrderRequestsTab from '../screens/Shipper/OrderRequestsTab';
import OrdersShipSuccessfullyTab from '../screens/Shipper/OrdersShipSuccessfullyTab';
import OrderRequestPage from '../screens/Shipper/OrderRequestPage';
///////////////
///Admin Pages
import AdminHomeTab from '../screens/Admin/AdminHomeTab';
import AdminProductsTab from '../screens/Admin/AdminProductsTab';
import AdminGarageSalesTab from '../screens/Admin/AdminGarageSalesTab';
import AdminUsersTab from '../screens/Admin/AdminUsersTab';
import AdminDeletedProductsTab from '../screens/Admin/AdminDeletedProductsTab';
import AdminDeletedGarageSalesTab from '../screens/Admin/AdminDeletedGarageSalesTab';
import AdminDeletedUsersTab from '../screens/Admin/AdminDeletedUsersTab';
//////////////

export const mainNavigation = [
    {
        name: 'Garago Home',
        subtitle: 'Home',
        url: '/',
        icon: 'home',
        roles: [Roles.All],
        exact: true,
        hasMenuItem: false,
        component: Home 
    },
    {
        name: 'Garage Sales Near By',
        subtitle: 'Sales Near By',
        url: '/garage_sales',
        icon: 'shop',
        roles: [Roles.All],
        exact: true,
        hasMenuItem: false,
        component: GarageSaleHome 
    },
    {
        name: 'Search Users',
        subtitle: 'Search Users',
        url: '/users',
        icon: 'user',
        roles: [Roles.All],
        exact: true,
        hasMenuItem: false,
        component: UsersHomePage 
    },
    {
        name: 'Garago Sale',
        subtitle: 'Garage Sale',
        url: '/garage_sales/:id',
        icon: null,
        roles: [Roles.All],
        exact: true,
        hasMenuItem: false,
        component: GarageSale 
    },
    {
        name: 'Login',
        subtitle: 'Login',
        url: '/login',
        icon: null,
        roles: [Roles.All],
        exact: true,
        hasMenuItem: false,
        component: Login 
    },
    {
        name: 'Register',
        subtitle: 'Register',
        url: '/register',
        roles: [Roles.All],
        icon: null,
        exact: true,
        hasMenuItem: false,
        component: Register
    }
];

export const garageSaleNavigation = [
    {
        name: 'Create Product',
        subtitle: 'Create Product',
        url: '/garage_sales/:id/products/:userId/create_product',
        icon: '',
        hasMenuItem: false,
        exact: true,
        roles: [Roles.Admin, Roles.Seller],
        component: CreateProduct
    },
    {
        name: 'Product Post Settings',
        subtitle: 'Product Post Settings',
        url: '/garage_sales/:id/products/:id/settings/:uniq_id',
        roles: [Roles.Admin, Roles.Seller],
        icon: '',
        hasMenuItem: false,
        exact: true,
        component: ProductSettings
    },
    {
        name: 'Shop Product',
        subtitle: 'Product',
        url: '/garage_sales/:id/products/:productId',
        roles: [Roles.Admin, Roles.Seller, Roles.Buyer],
        icon: 'product',
        exact: true,
        hasMenuItem: false,
        component: ProductPage 
    },
    {
        name: 'Garago Sale Reviews',
        subtitle: 'Garage Sale Reviews',
        url: '/garage_sales/:id/reviews',
        icon: null,
        roles: [Roles.Admin, Roles.Seller, Roles.Buyer, Roles.Shipper],
        exact: true,
        hasMenuItem: false,
        component: GarageSaleReviews 
    },
    {
        name: 'Create Garage Sale',
        subtitle: 'Create a new garage sale.',
        url: '/garage_sales/:userId/create_garage_sale',
        icon: null,
        roles: [Roles.Admin, Roles.Seller],
        exact: true,
        hasMenuItem: false,
        component: CreateGarageSale 
    },
    {
        name: 'Garage Sale Post Settings.',
        subtitle: 'Garage Sale Post settings.',
        url: '/garage_sales/:id/settings/:uniq_id',
        roles: [Roles.Admin, Roles.Seller],
        icon: null,
        exact: true,
        hasMenuItem: false,
        component: GarageSaleSettingsTab
    },
    {
        name: 'Sold History',
        subtitle: 'History of items sold.',
        url: '/garage_sales/:id/sold_history',
        icon: 'shop',
        roles: [Roles.Admin, Roles.Seller],
        exact: false,
        hasMenuItem: false,
        component: GarageSaleSoldHistoryTab 
    },
    {
        name: 'Delete History',
        subtitle: 'Items deleted.',
        url: '/garage_sales/:id/delete_history',
        icon: 'shop',
        roles: [Roles.Admin, Roles.Seller],
        exact: false,
        hasMenuItem: false,
        component: GarageSaleDeleteHistoryTab 
    },
    ///REserved products
    {
        name: "Reserved Products",
        subtitle: "Reserved Products for Garage Sale.",
        url: "/garage_sales/:id/reserved_products",
        icon: 'cart',
        roles: [Roles.Admin, Roles.Seller],
        exact: false,
        hasMenuItem: false,
        component: GarageSalesReserveProductsTab
    }
];

export const accountNavigation = [
   {
        name: 'Settings',
        subtitle: 'Account Settings',
        url: '/account/:uniq_id/settings',
        roles: [Roles.Buyer, Roles.Seller, Roles.Shipper, Roles.Admin],
        icon: null,
        exact: true,
        hasMenuItem: false,
        component: SettingsTab
    },
    {
        name: 'Edit Account',
        subtitle: 'Edit Account Page',
        url: '/account/:uniq_id/settings/edit',
        roles: [Roles.Buyer, Roles.Seller, Roles.Shipper, Roles.Admin],
        icon: null,
        exact: true,
        hasMenuItem: false,
        component: EditAccountTab
    },
    {
        name: 'User',
        subtitle: 'User',
        url: '/users/:id',
        roles: [Roles.All],
        icon: null, 
        exact: true,
        hasMenuItem: false,
        component: UserPage
    },
    {
        name: 'My Cart and Reserve',
        subtitle: 'My Cart and Reserve',
        url: '/account/:userId/my_cart',
        roles: [Roles.Buyer, Roles.Admin],
        icon: null,
        exact: false,
        hasMenuItem: false,
        component: MyCartTab
    }
];

export const shipperNavigation = [
    {
        name: `Shipper Order's Tab`,
        subtitle: `Order's Tab`,
        url: '/shipper_portal/:shipperId/orders',
        roles: [Roles.Admin, Roles.Shipper],
        icon: 'box',
        hasMenuItem: false,
        exact: true,
        component: OrdersTab
    }, 
    {
        name: `Shipper Order Request's Tab`,
        subtitle: `Order Request's Tan`,
        url: `/shipper_portal/:shipperId/order_requests`,
        roles: [Roles.Admin, Roles.Shipper],
        icon: `custom-box`,
        hasMenuItem: false,
        exact: true,
        component: OrderRequestsTab
    },
    {
        name: `Order's shipped successfully tab.`,
        subtitle: `Order Success history`,
        url: `/shipper_portal/:shipperId/order_success_history`,
        roles: [Roles.Admin, Roles.Shipper],
        icon: `custom-box`,
        exact: true,
        hasMenuItem: false,
        component: OrdersShipSuccessfullyTab,
    },
    {
        name: `Order Reqeust`,
        subttile: `Order Reqest`,
        url: `/shipper_portal/:shipperId/order_requests/:requestId`,
        roles: [Roles.Admin, Roles.Shipper],
        icon: `custom-request`,
        exact: true,
        hasMenuItem: false,
        component: OrderRequestPage
    }
];

export const adminNavigation = [
    {
        name: 'Admin Home Tab',
        subtitle: 'Admin Home',
        url: '/admin/:userId/',
        roles: [Roles.Admin],
        icon: 'home',
        exact: true,
        hasMenuItem: false,
        component: AdminHomeTab
    },
    {
        name: 'All Products Tab',
        subtitle: 'Admin Products',
        url: '/admin/:userId/products',
        roles: [Roles.Admin],
        icon: null,
        exact: true,
        hasMenuItem: false,
        component: AdminProductsTab
    },
    {
        name: 'All Garage Sales Tab',
        subtitle: 'Admin Garage Sales',
        url: '/admin/:userId/garage_sales',
        roles: [Roles.Admin],
        icon: null,
        exact: true,
        hasMenuItem: false,
        component: AdminGarageSalesTab
    },
    {
        name: 'All Users Tab',
        subtitle: 'Admin Users',
        url: '/admin/:userId/users',
        roles: [Roles.Admin],
        icon: null,
        exact: true,
        hasMenuItem: false,
        component: AdminUsersTab
    },
    {
        name: 'All Deleted Products Tab',
        subtitle: 'Admin Deleted Products',
        url: '/admin/:userId/deleted_products',
        roles: [Roles.Admin],
        icon: null,
        exact: true,
        hasMenuItem: false,
        component: AdminDeletedProductsTab
    },
    {
        name: 'All Deleted Garage Sales Tab',
        subtitle: 'Admin Deleted Garage Sales',
        url: '/admin/:userId/deleted_garage_sales',
        roles: [Roles.Admin],
        icon: null,
        exact: true,
        hasMenuItem: false,
        component: AdminDeletedGarageSalesTab
    },
    {
        name: 'All Deleted Users Tab',
        subtitle: 'Admin Deleted Users',
        url: '/admin/:userId/deleted_users',
        roles: [Roles.Admin],
        icon: 'home',
        exact: true,
        hasMenuItem: false,
        component: AdminDeletedUsersTab
    },
];

export default [...mainNavigation, ...garageSaleNavigation, ...accountNavigation, ...shipperNavigation, ...adminNavigation]