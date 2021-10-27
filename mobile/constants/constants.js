const onboarding_screens = [
    
]

const screens = {
    main_layout: "MainLayout",
    home: "Home",
    search: "Minha Lista",
    cart: "Carrinho",
    favourite: "Favoritos",
    notification: "Perfil",
    my_wallet: "Minha Carteira",
}

const bottom_tabs = [
    {
        id: 0,
        label: screens.home,
    },
    {
        id: 1,
        label: screens.search,
    },
    {
        id: 2,
        label: screens.cart,
    },
    {
        id: 3,
        label: screens.favourite,
    },
    {
        id: 4,
        label: screens.notification,
    },
]

const delivery_time = [
    {
        id: 1,
        label: "10 Mins",
    },
    {
        id: 2,
        label: "20 Mins"
    },
    {
        id: 3,
        label: "30 Mins"
    }
]

const ratings = [
    {
        id: 1,
        label: 1,
    },
    {
        id: 2,
        label: 2,
    },
    {
        id: 3,
        label: 3,
    },
    {
        id: 4,
        label: 4,
    },
    {
        id: 5,
        label: 5,
    }
]

const tags = [
    {
        id: 1,
        label: "Hamburguer"
    },
    {
        id: 2,
        label: "Pizza"
    },
    {
        id: 3,
        label: "Churrasco"
    },
    {
        id: 4,
        label: "Fruta"
    },
    {
        id: 5,
        label: "Sobremesa"
    },
    {
        id: 6,
        label: "Sushi"
    },
    {
        id: 7,
        label: "Massas"
    },
    {
        id: 7,
        label: "Bebidas"
    },
    {
        id: 8,
        label: "Pequeno-Almoço"
    }
]

export default {
    onboarding_screens,
    screens,
    bottom_tabs,
    delivery_time,
    ratings,
    tags
}