const path = require('path');
const webpack = require('webpack');
const htmlPlugin = require('html-webpack-plugin');

// const appDirectory = __dirname;

module.exports = {
    //Have it's entry path for your react app.
    //Use your polyfill for your react app.
    entry: ['whatwg-fetch', '@babel/polyfill', path.resolve(__dirname, 'index.js') ], 
    
    output: {
        //Have it output result be your bundle.index.js, and it will be in the dist folder.
        path: __dirname + '/dist',
        filename: 'bundle.index.js',
        //Have it's public path also be the home url.
        publicPath: '/'
    },

    devServer: {
        //Public path for your dev server
        publicPath: '/',
        //set the index file for your devServer.
        index: 'index.html',
        //Have your router fallback to your base url.
        historyApiFallback: true,
        port: 8000,
        //Enable your devServer to be served over to https.
        // https: true,
        //Enable your proxy to your .Net Core backend.
        proxy: {
            "/api": 'https://localhost:44329'
        },
        //
        contentBase: [path.join(__dirname, 'dist'), path.join(__dirname, 'assets')],
        //Havae it be compres for optimized performance
        compress: true
    },
    
    module: {
        //Define your loading rules for your bundler
        rules: [
            //Javascript loader.
            {
                test: /\.(js|jsx)$/,
                use: [
                    {
                        loader: 'babel-loader',
                        options: {
                            cacheDirectory: true
                        }
                    }
                ],
                exclude: /node_modules/
            },
            //Image loader.
            {
                test: /\.(jpg|png|jpeg|svg|gif|ico)$/,
                use: [
                    {
                        loader: 'url-loader'
                    }
                ]
            },
            //Loader for font-family
            {
                test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/,
                use: [
                    {
                        loader: 'url-loader?limit=10000&mimetype=application/font-woff'
                    }
                ]
            },
            //Loader for font-family and ui frameworks.
            {
                test: /\.(ttf|eot)(\?v=[0-9]\.[0-9]\.[0-9])?$/,
                use: [
                    {
                        loader: 'file-loader'
                    }
                ]
            },
            {
                test: /\.otf(\?.*)?$/,
                use: 'file-loader?name=/fonts/[name].  [ext]&mimetype=application/font-otf'
            },
            {
                //Css, less, sasss loader for files relating to the your node modules.
                //Test proeprty would be a regex pattern for the file
                test: /\.(le|sc|c)ss$/,
                //THen the use property will be used to specify what loader to use for the corresponding regular expression.
                use: [
                    'style-loader',
                    {
                        loader: 'css-loader',
                        options: {
                            sourceMap: true
                        }
                    },
                    {
                        loader: 'sass-loader',
                        options: {
                            sourceMap: true
                        }
                    },
                    'postcss-loader',
                    {
                        loader: 'less-loader',
                        options: {
                            includePaths: [ path.resolve(__dirname, '/node_modules')  ],
                            javascriptEnabled: true
                        }
                    }
                ]
            }   
        ],
        
    },

    //Resolve the extensions for your webpack bundler.
    resolve: {
        extensions: [ '.ts', '.tsx', '.js', '.jsx', '.scss', '.css', '.less' ]
    },

    //Add extra webpack plugin to use the index.html file as a template.
    plugins: [
 // `process.env.NODE_ENV === 'production'` must be `true` for production
        // builds to eliminate development checks and reduce build size. You may
        // wish to include additional optimizations.
        // new webpack.DefinePlugin({
        //     'process.env.NODE_ENV': JSON.stringify('development'), // Tells React to build in either dev or prod modes. https://facebook.github.io/react/downloads.html (See bottom)
        //     'process.env.API_MODE': JSON.stringify('server'), // mock or server - telling APIs which version to use; requires restart of app if changed
        //     'process.env.DELAY': JSON.stringify('1000'), // delay that the mock APIs timeout with to simulate an API call delay
        //     'process.env.PLATFORM': JSON.stringify('web'),
        //     __DEV__: process.env.NODE_ENV !== 'production' || true
        // }),
        new htmlPlugin({
            title: 'Garago',
            inject: 'body',
            template:  './index.html',
            cache: true
        }),
        new webpack.DefinePlugin({
            'process.env.CLIENT_URL': JSON.stringify('http://localhost:8000'),
            'process.env.API_MODE': JSON.stringify('server'),
            'process.env.FIREBASE_APP_ID': JSON.stringify('garago-204107'),
            'process.env.FIREBASE_AUTH_DOMAIN': JSON.stringify('garago-204107.firebaseapp.com'),
            'process.env.FIREBASE_API_KEY': JSON.stringify('AIzaSyBOFKf0RvsCHwO08_SVAUak6wKnhH-0EzE'),
            // 'process.env.FIREBASE_WEB_API': JSON.stringify(''),
            'process.env.FIREBASE_DB_URL': JSON.stringify('https://garago-204107.firebaseio.com'),
            'process.env.FIREBASE_STORAGE_BUCKET': JSON.stringify('garago-204107.appspot.com'),
            'process.env.FIREBASE_MESSAGE_ID': JSON.stringify('1010680615313'),
            'process.env.FIREBASE_CLIENT_ID': JSON.stringify('1010680615313-6ivuddmqmb85dusnoej6q6npppjdp3gp.apps.googleusercontent.com'),
            'process.env.FIREBASE_CLIENT_SECRET': JSON.stringify('TPVBbZ_tGVHy_PPYC8sB5xMn'),
            'process.env._DEV_': process.env.NODE_ENV !== 'production' || true
        })
    ]

}