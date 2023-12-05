export const ACTION = {
    UPDATE_CART: "update_cart",
    CLEAR_CART: "clear_cart",
    UPDATE_FAVORITE: "update_favorite",
    CLEAR_FAVORITE: "clear_favorite"
}

const  reducer = (state, action)=>{ //action: type - payload
    switch(action.type){
        case ACTION.UPDATE_CART: return {...state,cart:action.payload};
        case ACTION.CLEAR_CART: return {...state,cart:[]};
        case ACTION.UPDATE_FAVORITE: return {...state,favorite:action.payload};
        case ACTION.CLEAR_FAVORITE: return {...state,favorite:[]};

        default: return state;
    }
}

export default reducer;