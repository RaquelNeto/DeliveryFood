import React, { useState, useEffect} from 'react'
import { StyleSheet, View, Text, TouchableOpacity } from 'react-native'
import { PaymentView } from '../../components/PaymentView'
import axios  from 'axios';

const PaymentScreen = () => {

    const [ response, setResponse ] = useState()
    
    const [ makePayment, setMakePayment ] = useState(false)
    const [ paymentStatus, setPaymentStatus ] = useState('')

    const cartInfo = {
        id: '5eruyt35eggr76476236523t3',
        description: 'Hamburguer',
        amount: 1
    }

    const onCheckStatus = async (paymentResponse) => {
        setPaymentStatus('Por favor aguarde enquanto confirma o seu pagamento!')
        setResponse(paymentResponse)

        let jsonResponse = JSON.parse(paymentResponse);
        // perform operation to check payment status

        try {
    
            const stripeResponse = await axios.post('http://localhost:44335/payment', {
                email: 'lucasneto@hotmail.com',
                product: cartInfo,
                authToken: jsonResponse
            })

            if(stripeResponse){

                const { paid } = stripeResponse.data;
                if(paid === true){
                    setPaymentStatus('Pagamento bem sucedido')
                }else{
                    setPaymentStatus('O pagamento falhou devido a algum problema! ')
                }

            }else{
                setPaymentStatus(' O pagamento falhou devido a algum problema! ')
            }

            
        } catch (error) {
            
            console.log(error)
            setPaymentStatus(' O pagamento falhou devido a algum problema! ')

        }
 
    }


    const paymentUI = () => {

        if(!makePayment){

            return <View style={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', alignItems: 'center', height: 300, marginTop: 50}}>
                    <Text style={{ fontSize: 25, margin: 10}}> Efetuar Pagamento </Text>
                    <Text style={{ fontSize: 18, margin: 10}}> Descrição Produto: {cartInfo.description} </Text>
                    <Text style={{ fontSize: 16, margin: 10}}> Montante a Pagar: {cartInfo.amount} </Text>

                    <TouchableOpacity style={{ height: 60, width: 300, backgroundColor: '#0A3C57', borderRadius: 30, justifyContent: 'center', alignItems: 'center'
                        }}
                        onPress={() => {
                            setMakePayment(true)
                        }}
                        >
                        <Text style={{ color: '#FFF', fontSize: 20}}>
                            Efetuar Pagamento
                        </Text>

                    </TouchableOpacity>


                </View>


             
            // show to make payment
        }else{

            if(response !== undefined){
                return <View style={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', alignItems: 'center', height: 300, marginTop: 50}}>
                    <Text style={{ fontSize: 25, margin: 10}}> { paymentStatus} </Text>
                    <Text style={{ fontSize: 16, margin: 10}}> { response} </Text>
                </View>

            }else{
                return <PaymentView onCheckStatus={onCheckStatus} product={cartInfo.description} amount={cartInfo.amount} />

            }
            
        }

    }


return (<View style={styles.container}>
            {paymentUI()}
        </View>)}


const styles = StyleSheet.create({
container: { flex: 1, paddingTop: 100},
navigation: { flex: 2, backgroundColor: 'red' },
body: { flex: 10, justifyContent: 'center', alignItems: 'center', backgroundColor: 'yellow' },
footer: { flex: 1, backgroundColor: 'cyan' }
})

 
 
 export default PaymentScreen