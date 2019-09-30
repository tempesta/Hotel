var express = require('express');
var app = express();
app.use(express.static('app'));
app.get('/', function (req, res,next) {
 res.redirect('/'); 
});
app.listen(80, 'localhost');