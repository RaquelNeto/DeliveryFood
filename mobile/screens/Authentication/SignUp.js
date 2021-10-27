import React from "react";
import { View, Text, TouchableOpacity, Image,} from "react-native";

import { AuthLayout } from "../";
import { FONTS, SIZES, COLORS, icons, } from "../../constants"
import { FormInput, TextButton, TextIconButton} from "../../components"
import { utils } from "../../utils";

const SignUp = ({ navigation }) => {
    const [email, setEmail] = React.useState("")
    const [username, setUsername] = React.useState("")
    const [password, setPassword] = React.useState("")
    const [showPass, setShowPass] = React.useState(false)

    const [emailError, setEmailError] = React.useState("")
    const [usernameError, setUsernameError] = React.useState("")
    const [passwordError, setPasswordError] = React.useState("")

    function isEnableSignUp() {
        return email != "" && username != "" && password != "" && emailError == "" && passwordError == ""
    }

    return (
        <AuthLayout
            title="Registe-se"
            titleContainerStyle={{
                marginTop: 10
            }}
        >
            <View
                style={{
                    flex: 1,
                    marginTop: -10
                }}
            >
                <FormInput
                    label="Email"
                    keyboardType="email-address"
                    autoCompleteType="email"
                    onChange={(value) => {
                        utils.validateEmail(value, setEmailError)
                        setEmail(value)
                    }}
                    errorMsg={emailError}
                    appendComponent={
                        <View
                            style={{
                                justifyContent: 'center'
                            }}
                        >
                            <Image
                                source={(email == "") || (email != "" && emailError == "") ? icons.correct : icons.cancel}
                                style={{
                                    height: 20,
                                    width: 20,
                                    tintColor: (email == "") ? COLORS.gray : (email != "" && emailError == "") ? COLORS.green : COLORS.red
                                }}
                            />
                        </View>
                    }
                />

                <FormInput
                    label="Nome"
                    containerStyle={{
                        marginTop: SIZES.radius
                    }}
                    onChange={(value) => {
                        setUsername(value)
                    }}
                    errorMsg={usernameError}
                    appendComponent={
                        <View
                            style={{
                                justifyContent: 'center',
                                marginTop: -20
                            }}
                        >
                            <Image
                                source={(username == "") || (username != "" && usernameError == "") ? icons.correct : icons.cancel}
                                style={{
                                    height: 20,
                                    width: 20,
                                    tintColor: (username == "") ? COLORS.gray : (username != "" && usernameError == "") ? COLORS.green : COLORS.red
                                }}
                            />
                        </View>
                    }
                />

                <FormInput
                    label="Password"
                    secureTextEntry={!showPass}
                    autoCompleteType="password"
                    containerStyle={{
                        marginTop: SIZES.radius
                    }}
                    onChange={(value) => {
                        utils.validatePassword(value, setPasswordError)
                        setPassword(value)
                    }}
                    errorMsg={passwordError}
                    appendComponent={
                        <TouchableOpacity
                            style={{
                                width: 40,
                                alignItems: 'flex-end',
                                justifyContent: 'center',
                            }}
                            onPress={() => setShowPass(!showPass)}
                        >
                            <Image
                                source={showPass ? icons.eye_close : icons.eye}
                                style={{
                                    height: 20,
                                    width: 20,
                                    tintColor: COLORS.gray
                                }}
                            />
                        </TouchableOpacity>
                    }
                />

                <FormInput
                    label="Confirmar Password"
                    secureTextEntry={!showPass}
                    autoCompleteType="password"
                    containerStyle={{
                        marginTop: SIZES.radius
                    }}
                    onChange={(value) => {
                        utils.validatePassword(value, setPasswordError)
                        setPassword(value)
                    }}
                    errorMsg={passwordError}
                    appendComponent={
                        <TouchableOpacity
                            style={{
                                width: 40,
                                alignItems: 'flex-end',
                                justifyContent: 'center',
                            }}
                            onPress={() => setShowPass(!showPass)}
                        >
                            <Image
                                source={showPass ? icons.eye_close : icons.eye}
                                style={{
                                    height: 20,
                                    width: 20,
                                    tintColor: COLORS.gray
                                }}
                            />
                        </TouchableOpacity>
                    }
                />

                 <FormInput
                    label="Telemóvel"
                    containerStyle={{
                        marginTop: SIZES.radius
                    }}
                    onChange={(value) => {
                        setUsername(value)
                    }}
                    errorMsg={usernameError}
                    appendComponent={
                        <View
                            style={{
                                justifyContent: 'center'
                            }}
                        >
                            <Image
                                source={(username == "") || (username != "" && usernameError == "") ? icons.correct : icons.cancel}
                                style={{
                                    height: 20,
                                    width: 20,
                                    tintColor: (username == "") ? COLORS.gray : (username != "" && usernameError == "") ? COLORS.green : COLORS.red
                                }}
                            />
                        </View>
                    }
                />

                {/* Sign Up & Sign In */}
                <TextButton
                    label="Registe-se"
                    disabled={isEnableSignUp() ? false : true}
                    buttonContainerStyle={{
                        height: 50,
                        alignItems: 'center',
                        marginTop: 10,
                        borderRadius: SIZES.radius,
                        backgroundColor: isEnableSignUp() ? COLORS.primary : COLORS.transparentPrimary,
                    }}
                    onPress={() => navigation.navigate("Otp")}
                />

                <View
                    style={{
                        flexDirection: 'row',
                        marginTop: 5,
                        justifyContent: 'center'
                    }}
                >
                    <Text style={{ color: COLORS.darkGray, ...FONTS.body3 }}>Já possui uma conta? </Text>
                    <TextButton
                        label="Login"
                        buttonContainerStyle={{
                            backgroundColor: null
                        }}
                        labelStyle={{
                            color: COLORS.primary,
                            ...FONTS.h3
                        }}
                        onPress={() => navigation.goBack()}
                    />
                </View>
            </View>
        </AuthLayout>
    )
}

export default SignUp