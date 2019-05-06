//Define ROles for your users
//They would be the admin which would be you that case.
export const Admin = 'Admin';
//Then there would be the seller or a user with a garagesale communicating with buyer.
export const Seller = 'Seller';
//Or you would be restricted when communicating with the seller which in that case would be the buyer.
export const Buyer = 'Buyer';
//Then you could also be the shipper if they want it shipped, and as the shipper you could only what is related to shipping the order.
export const Shipper = 'Shipper';
//Or you could have all roles.
export const All = 'All';