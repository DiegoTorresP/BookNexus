
    var chart_config = {
        chart: {
            container: "#collapsable-example",

            animateOnInit: true,
            
            node: {
                collapsable: true
            },
            animation: {
                nodeAnimation: "easeOutBounce",
                nodeSpeed: 700,
                connectorsAnimation: "bounce",
                connectorsSpeed: 700
            }
        },
        nodeStructure: {
            HTMLclass: 'gray',
            text: {
                title: "Bookzu"
            },
            children: [
                {
                    text: {
                        title: "Inicio"
                    },
                    link: {
                        href: "../../Home/Index"
                    },
                    collapsed: true,
                    children: [

                        {
                            text: {
                                title: "Privacidad"
                            },
                            link: {
                                href: "../../Home/Privacy"
                            }
                        },
                        {
                            text: {
                                title: "Sitemap"
                            },
                            link: {
                                href: "../../Home/Sitemap"
                            }
                        }
                    ]
                },
                {
                    text: {
                        title: "Libros"
                    },
                    link: {
                        href: "../../Books/Index"
                    },
                    childrenDropLevel: 1,
                    collapsed: true,
                    children: [

                        {
                            text: {
                                title: "Crear Libro"
                            },
                            link: {
                                href: "../../Books/Create"
                            }
                        }
                    ]
                },
                //{
                //    pseudo: true,
                //    children: [
                //        {
                //            image: "img/cheryl.png"
                //        },
                //        {
                //            image: "img/pam.png"
                //        }
                //    ]
                //}
            ]
        }
    };

/* Array approach
    var config = {
        container: "#collapsable-example",

        animateOnInit: true,
        
        node: {
            collapsable: true
        },
        animation: {
            nodeAnimation: "easeOutBounce",
            nodeSpeed: 700,
            connectorsAnimation: "bounce",
            connectorsSpeed: 700
        }
    },
    malory = {
        image: "img/malory.png"
    },

    lana = {
        parent: malory,
        image: "img/lana.png"
    }

    figgs = {
        parent: lana,
        image: "img/figgs.png"
    }

    sterling = {
        parent: malory,
        childrenDropLevel: 1,
        image: "img/sterling.png"
    },

    woodhouse = {
        parent: sterling,
        image: "img/woodhouse.png"
    },

    pseudo = {
        parent: malory,
        pseudo: true
    },

    cheryl = {
        parent: pseudo,
        image: "img/cheryl.png"
    },

    pam = {
        parent: pseudo,
        image: "img/pam.png"
    },

    chart_config = [config, malory, lana, figgs, sterling, woodhouse, pseudo, pam, cheryl];

*/