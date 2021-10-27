import React from 'react';
import { View, Text, StyleSheet, Image, SafeAreaView } from 'react-native';
import { Title, Caption, TouchableRipple, } from 'react-native-paper';
import { FONTS, SIZES, COLORS, icons, dummyData, images } from "../../constants";
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';


const Notification = ({ navigation }) => {

    return (

        <SafeAreaView style={styles.container}>

            <View style={styles.userInfoSection}>
                <View style={{ justifyContent: 'center',
                               alignItems: 'center', }} >
                    <Image
                        source={images.user}
                        style={{
                            height: 80,
                            width: 80,
                        }}
                    />

                    <View>
                        <Title style={[styles.title, { marginTop:15, marginBottom: 5, marginLeft: 20 }]} >
                            Lucas Neto
                        </Title>
                        <Caption style={styles.caption}>lucasneto@hotmail.com</Caption>
                    </View>             

                </View>
            </View>    


            <View style={styles.menuWrapper}>
                <TouchableRipple onPress={() => {}}>
                    <View style={styles.menuItem}>
                        <Icon name="account-outline" size={25} style={{color: COLORS.primary, marginRight: 10}}/>
                        <Text >Meu Perfil</Text>
                    </View>
                </TouchableRipple>

                <TouchableRipple onPress={() => {}}>
                    <View style={styles.menuItem}>
                        <Icon name="heart-outline" size={25} style={{color: COLORS.primary, marginRight: 10}}/>
                        <Text >Favoritos</Text>
                    </View>
                </TouchableRipple>

                <TouchableRipple onPress={() => {}}>
                    <View style={styles.menuItem}>
                        <Icon name="credit-card" size={25} style={{color: COLORS.primary, marginRight: 10}}/>
                        <Text >Definições de Pagamento</Text>
                    </View>
                </TouchableRipple>

                <TouchableRipple onPress={() => {}}>
                    <View style={styles.menuItem}>
                        <Icon name="information" size={25} style={{color: COLORS.primary, marginRight: 10}}/>
                        <Text >Sobre Nós</Text>
                    </View>
                </TouchableRipple>

                <TouchableRipple onPress={() => {}}>
                    <View style={styles.menuItem}>
                        <Icon name="cog" size={25} style={{color: COLORS.primary, marginRight: 10}}/>
                        <Text >Definições</Text>
                    </View>
                </TouchableRipple>
            </View>

        </SafeAreaView>
    )
}

export default Notification;


const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  userInfoSection: {
    paddingHorizontal: 30,
    marginBottom: 25,
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    justifyContent: 'center',
    alignItems: 'center',
  },
  caption: {
    fontSize: 14,
    lineHeight: 14,
    fontWeight: '500',
    justifyContent: 'center',
    alignItems: 'center',
  },
  row: {
    flexDirection: 'row',
    marginBottom: 10,
  },
  infoBoxWrapper: {
    borderBottomColor: '#dddddd',
    borderBottomWidth: 1,
    borderTopColor: '#dddddd',
    borderTopWidth: 1,
    flexDirection: 'row',
    height: 100,
  },
  infoBox: {
    width: '50%',
    alignItems: 'center',
    justifyContent: 'center',
  },
  menuWrapper: {
    marginTop: 10,
  },
  menuItem: {
    flexDirection: 'row',
    paddingVertical: 15,
    paddingHorizontal: 30,
  },
  menuItemText: {
    color: '#777777',
    marginLeft: 20,
    fontWeight: '600',
    fontSize: 16,
    lineHeight: 26,
  },
});