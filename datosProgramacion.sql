use Ecommerce
go


INSERT INTO Categoria
VALUES
  ('Tortas Clásicas'),      -- ID 1
  ('Tartas'),               -- ID 2
  ('Tortas Temáticas'),     -- ID 3
  ('Servicio de Lunch'),    -- ID 4
  ('Bocaditos Dulces'),     -- ID 5
  ('Mini Tortas');          -- ID 6
  

INSERT INTO Producto (codigo, nombre, descripcion, precio, stock, unidad_venta, id_categoria) VALUES
('TC001', 'Tiramisú', 'Clásico postre italiano con capas de café, mascarpone y cacao.', 40000.00, 10, 'unidad', 1),
('TC002', 'Chocotorta', 'Torta de galletas de chocolate, dulce de leche y queso crema.', 4200.00, 10, 'unidad', 1),
('TC003', 'Cheesecake', 'Tarta fría con base de galleta y crema de queso.', 4300.00, 10, 'unidad', 1),
('TC004', 'Mousse de chocolate', 'Torta suave con mousse de chocolate intenso.', 4600.00, 10, 'unidad', 1),
('TC005', 'Rogel', 'Capas de masa crocante con dulce de leche y merengue.', 4700.00, 10, 'unidad', 1),
('TC006', 'Charlotte tropical', 'Postre fresco hecho con vainillas y un bavaroise de frutas.', 4800.00, 10, 'unidad', 1),
('TC007', 'Brownie con dulce y merengue', 'Brownie con dulce de leche y merengue italiano.', 4400.00, 10, 'unidad', 1),
('TC008', 'Pavlova', 'Torta de merengue con frutas, dulce y crema batida.', 4600.00, 10, 'unidad', 1),

('TAR001', 'Tarta de frutilla', 'Tarta con base crocante, crema chantilly y frutillas frescas.', 4300.00, 10, 'unidad', 2),
('TAR002', 'Saint Honoré', 'Tarta con masa hojaldrada, caramelo, bombas de pastelera y crema chantilly.', 4700.00, 10, 'unidad', 2),
('TAR003', 'Lemon Pie', 'Tarta con crema de limón y merengue italiano.', 4200.00, 10, 'unidad', 2),
('TAR004', 'Tarta de lima', 'Tarta fresca con crema de lima y base de galleta.', 4250.00, 10, 'unidad', 2),

('TT001', 'Letter Cake', 'Torta decorada en forma de letra con crema y toppings.', 5500.00, 10, 'unidad', 3),
('TT002', 'Number Cake', 'Torta decorada en forma de número con crema y toppings.', 5500.00, 10, 'unidad', 3),
('TT003', 'Torta Buttercream', 'Torta de bizcochuelo decorada con buttercream.', 5800.00, 10, 'unidad', 3),
('TT004', 'Torta Forrada', 'Torta cubierta con fondant, perfecta para eventos especiales.', 6000.00, 10, 'unidad', 3),

('LUN001', 'Sandwiches de miga', 'Sandwiches de miga surtidos, clásicos y sabrosos.', 3000.00, 10, 'docena', 4),
('LUN002', 'Sacramentos', 'Sacramentos rellenos de tomate y pollo.', 3200.00, 10, 'docena', 4),
('LUN003', 'Fosforitos', 'Mini hojaldres rellenos, decorados con glase.', 3100.00, 10, 'docena', 4),
('LUN004', 'Chips', 'Chips salados variados para acompañar el lunch.', 2800.00, 10, 'docena', 4),
('LUN005', 'Calentitos', 'Samosas, bombas de humita y tartaletas de verdura.', 3300.00, 10, 'docena', 4),
('LUN006', 'Saladitos', 'Mini tartitas de hojaldre de rellenos variados, salados y fríos.', 3400.00, 10, 'docena', 4),
('LUN007', 'Ciabattas', 'Mini panes tipo ciabatta rellenos de rucula y crudo.', 3500.00, 10, 'docena', 4),
('LUN008', 'Pernil', 'Pernil horneado, acompañado de panes y salsas.', 7000.00, 5, 'unidad', 4),

('BD001', 'Alfajores de nuez', 'Alfajores de nuez con dulce de leche.', 2500.00, 20, 'docena', 5),
('BD002', 'Marplatenses de chocolate', 'Alfajores cubiertos en chocolate, estilo marplatense.', 2600.00, 20, 'docena', 5),
('BD003', 'Alfajores de coco', 'Alfajores con coco rallado y dulce de leche.', 2500.00, 20, 'docena', 5),
('BD004', 'Canelé', 'Dulce francés caramelizado por fuera y cremoso por dentro.', 2700.00, 20, 'docena', 5),
('BD005', 'Macarons', 'Petit four francés, relleno de ganache.', 2900.00, 20, 'docena', 5),
('BD006', 'Scones', 'Bollitos dulces típicos ingleses, ideales para el té.', 2400.00, 20, 'docena', 5),
('BD007', 'Cookies', 'Galletas artesanales con chips de chocolate y nuez.', 2300.00, 20, 'docena', 5),

('MT001', 'Vasitos', 'Vasitos individuales de mousse, tiramisu o cheesecake.', 2000.00, 30, 'docena', 6),
('MT002', 'Mini tartas', 'Mini tartas surtidas ideales para porciones individuales.', 2200.00, 30, 'docena', 6);



INSERT INTO Imagen (id_producto, imagen_url) VALUES
(1, 'img/tiramisu.jpg'),
(2, 'img/chocotorta.jpg'),
(3, 'img/cheesecake.jpg'),
(4, 'img/mousse.jpg'),
(5, 'img/rogel.jpg'),
(6, 'img/charlotte.jpg'),
(7, 'img/brownie.jpg'),
(8, 'img/pavlova.jpg'),
(9, 'img/tarta_frutilla.jpg'),
(10, 'img/saint_honore.jpg'),
(11, 'img/lemon_pie.jpg'),
(12, 'img/tarta_lima.jpg'),
(13, 'img/letter_cake.jpg'),
(14, 'img/number_cake.jpg'),
(15, 'img/buttercream.jpg'),
(16, 'img/torta_forrada.jpg'),
(17, 'img/miga.jpg'),
(18, 'img/sacramentos.jpg'),
(19, 'img/fosforitos.jpg'),
(20, 'img/chips.jpg'),
(21, 'img/calentitos.jpg'),
(22, 'img/saladitos.jpg'),
(23, 'img/ciabatta.jpg'),
(24, 'img/pernil.jpg'),
(25, 'img/alf_nuez.jpg'),
(26, 'img/marplatenses.jpg'),
(27, 'img/alf_coco.jpg'),
(28, 'img/canele.jpg'),
(29, 'img/macarons.jpg'),
(30, 'img/scones.jpg'),
(31, 'img/cookies.jpg'),
(32, 'img/vasitos.jpg'),
(33, 'img/mini_tartas.jpg');


INSERT INTO Imagen (id_producto, imagen_url)
VALUES 
(21, 'img/humita.jpg'),
(21, 'img/samosa.jpg');


INSERT INTO TipoUsuario (descripcion) 
VALUES ('Cliente'), ('Administrador');

INSERT INTO Usuario (mail, pass, id_tipo_usuario, dni, nombre, apellido, direccion, ciudad, codigo_postal, telefono)
VALUES ('admin@miapp.com', 'admin123', 2, '12345678', 'Admin', 'Principal', 'Calle Falsa 123', 'Buenos Aires', 1000, '1234567890');