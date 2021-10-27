import React from "react";
import { createStackNavigator } from "@react-navigation/stack";
import { NavigationContainer } from '@react-navigation/native';

import CustomDrawer from './navigation/CustomDrawer';

import { createStore, applyMiddleware } from "redux";
import { Provider } from "react-redux";
import { useFonts } from 'expo-font';
import thunk from "redux-thunk";
import rootReducer from "./stores/rootReducer";

import {
    SignIn,
    SignUp,
    ForgotPassword,
    Otp,
    Map,
    Chat,
    Product,
    QrCode,
    PaymentScreen
} from "./screens";


const Stack = createStackNavigator();

const store = createStore(
    rootReducer,
    applyMiddleware(thunk)
)

const App = () => {

    const [loaded] = useFonts({
        "Poppins-Black": require('./assets/fonts/Poppins-Black.ttf'),
        "Poppins-Bold": require('./assets/fonts/Poppins-Bold.ttf'),
        "Poppins-SemiBold": require('./assets/fonts/Poppins-SemiBold.ttf'),
        "Poppins-Regular": require('./assets/fonts/Poppins-Regular.ttf'),
    })

    if (!loaded) {
        return null;
    }
    return (
        <Provider store={store}>
            <NavigationContainer>
                <Stack.Navigator
                    screenOptions={{
                        headerShown: false
                    }}
                    initialRouteName={'SignIn'}
                >

                    <Stack.Screen
                        name="SignIn"
                        component={SignIn}
                    />

                    <Stack.Screen
                        name="SignUp"
                        component={SignUp}
                    />

                    <Stack.Screen
                        name="ForgotPassword"
                        component={ForgotPassword}
                    />

                    <Stack.Screen
                        name="Otp"
                        component={Otp}
                    />

                    <Stack.Screen
                        name="Map"
                        component={Map}
                    />

                    <Stack.Screen
                        name="Chat"
                        component={Chat}
                    />

                    <Stack.Screen
                        name="PaymentScreen"
                        component={PaymentScreen}
                    />

                    <Stack.Screen
                        name="Product"
                        component={Product}
                    />

                    <Stack.Screen
                        name="QrCode"
                        component={QrCode}
                    />

                    <Stack.Screen
                        name="Home"
                        component={CustomDrawer}
                    />

                </Stack.Navigator>
            </NavigationContainer>
        </Provider>
    )
}

export default App