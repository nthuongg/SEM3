import React from "react";

const Context = React.createContext(); //create global state

export const ContextProvider = Context.Provider;
export default Context;