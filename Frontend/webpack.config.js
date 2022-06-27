const path = require('path');

  module.exports = {
    entry: {
      spa: './index.tsx'
    },
    module: {
      rules: [
        {
          test: /\.tsx?$/,
          use: 'babel-loader',
          exclude: /node_modules/,
        },
        {
            test: /\.css$/,
            use: ["style-loader", "css-loader"],
        },
      ],
    },
    resolve: {
      extensions: [ '.tsx', '.ts', '.js' ],
    },
    output: {
      filename: 'bundle.js',
      path: path.join(__dirname, '../wwwroot'),
      libraryTarget: 'var',
      library: 'spa'
    },
    mode: "development"
  };