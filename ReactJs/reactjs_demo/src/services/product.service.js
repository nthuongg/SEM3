import api from "./api";

export const get_product = async (limit)=>{
    try {
        const url = `products?limit=${limit}`;
        const rs = await api.get(url);
        return rs.data.products;
    } catch (error) {
        return [];
    }
}

export const detail_product = async (id)=>{
     try {
        const url = `products/${id}`;
        const rs = await api.get(url);
        return rs.data;
    } catch (error) {
        return {};
    }
}