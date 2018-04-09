const path = require("path");
const HtmlWebPackPlugin = require("html-webpack-plugin");

module.exports = {
  entry: ["./index.jsx"],
  output: {
    path: path.resolve(__dirname, "dist"),
    filename: "js/[name].js"
  },
  module: {
    rules: [
      {
        loader: 'babel-loader',
        test: /(\.jsx|\.js)$/,
        exclude: /node_modules/
      }
    ]
  },
  devServer: {
    port: 3000
  },
  plugins: [
    new HtmlWebPackPlugin({
      template: "./index.html",
      filename: "./index.html"
    })
  ]
};