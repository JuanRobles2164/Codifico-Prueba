import { Order } from "../Order";
import { OrderDetails } from "../OrderDetails";

export interface CreateOrderWithProductsRequest{
    NewOrder: Order,
    NewOrderDetails: OrderDetails[]
};