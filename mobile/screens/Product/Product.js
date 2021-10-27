import React from "react";
import { View, Text, TouchableOpacity, Image,} from "react-native";

import { FONTS, SIZES, COLORS, icons, } from "../../constants"
import { FormInput, TextButton, TextIconButton} from "../../components"

const Product = ({ navigation }) => {

    return (
        <View
            style={{
                flex: 1,
                alignItems: 'center',
                justifyContent: 'center'
            }}
        >
            <Text>Product</Text>
        </View>
    )
}

export default Product