import React from "react";
import { View, Text, TouchableOpacity, Image,} from "react-native";

import { FONTS, SIZES, COLORS, icons, } from "../../constants"
import { FormInput, TextButton, TextIconButton} from "../../components"

const Chat = ({ navigation }) => {

    return (
        <View
            style={{
                flex: 1,
                alignItems: 'center',
                justifyContent: 'center'
            }}
        >
            <Text>Chat</Text>
        </View>
    )
}

export default Chat