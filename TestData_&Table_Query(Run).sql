-- Insert regular products (non-auction items)
INSERT INTO [dbo].[Product] ([name], [price], [category], [description], [active], [quatity], [icon], [dateBid])
VALUES 
('Calculus: Early Transcendentals', 889.99, 'Textbook', 'Comprehensive calculus textbook for university students', 1, 15, 'https://www.wiley.com/storefront-pdp-assets/_next/image?url=https%3A%2F%2Fmedia.wiley.com%2Fproduct_data%2FcoverImage300%2F24%2F11188841%2F1118884124.jpg&w=384&q=75', '2000-01-01'),
('MacBook Air 13"', 14000.00, 'Electronics', 'Latest MacBook Air with M2 chip, perfect for students', 1, 8, 'https://media.wired.com/photos/65ea34d70264b0ad869cbc18/master/w_1600,c_limit/MacBook-Air-M3-Review-Featured-Gear.jpg', '2000-01-01'),
('LED Desk Lamp with USB', 799.99, 'Dorm Essential', 'Adjustable LED desk lamp with USB charging port', 1, 25, 'https://img.fruugo.com/product/4/20/1724795204_max.jpg', '2000-01-01'),
('5-Pack College Ruled Notebooks', 449.99, 'Stationery', 'Set of 5 college-ruled notebooks for note-taking', 1, 50, 'https://media.accobrands.com/media/560-560/517179.jpg?width=560px&height=560px', '2000-01-01'),
('Physics for Scientists and Engineers', 950.00, 'Textbook', 'University physics textbook with latest edition', 1, 12, 'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1347711281i/13018799.jpg', '2000-01-01'),
('Wireless Mouse', 299.99, 'Electronics', 'Ergonomic wireless mouse for laptops and desktops', 1, 30, 'https://m.media-amazon.com/images/I/61xPVoKJT5L._AC_SL1500_.jpg', '2000-01-01'),
('Bedding Set', 1200.00, 'Dorm Essential', 'Complete bedding set for dorm rooms', 1, 10, 'https://m.media-amazon.com/images/I/91z6w7vN1aL._AC_SL1500_.jpg', '2000-01-01'),
('Stapler and Staple Remover Set', 150.00, 'Stationery', 'Essential office supplies for students', 1, 40, 'https://m.media-amazon.com/images/I/71J8UzVqHaL._AC_SL1500_.jpg', '2000-01-01');

-- Insert auction products (with future dateBid)
INSERT INTO [dbo].[Product] ([name], [price], [category], [description], [active], [quatity], [icon], [dateBid])
VALUES 
('iPad Pro (2022)', 5999.99, 'Electronics', 'Like-new iPad Pro with M2 chip and accessories', 1, 1, 'https://preview.redd.it/got-a-used-ipad-pro-m2-11-for-600-v0-wk499ndgyj3d1.jpeg?width=1080&crop=smart&auto=webp&s=aac785f686b76971cf5656b2fdeab7f3630075bc', DATEADD(DAY, 7, GETDATE())),
('Sony WH-CH720N Wireless Headphones', 1499.99, 'Electronics', 'Premium noise cancelling wireless headphones', 1, 1, 'https://m.media-amazon.com/images/I/51rpbVmi9XL._AC_SL1200_.jpg', DATEADD(DAY, 3, GETDATE())),
('TI-84 Plus Graphing Calculator', 400.00, 'Stationery', 'Graphing calculator for engineering and math students', 1, 1, 'https://m.media-amazon.com/images/I/51IVZSZsWnL._SL500_.jpg', DATEADD(DAY, 5, GETDATE())),
('Gaming Laptop', 8500.00, 'Electronics', 'High-performance gaming laptop for computer science students', 1, 1, 'https://m.media-amazon.com/images/I/71fTFZ5d9xL._AC_SL1500_.jpg', DATEADD(DAY, 10, GETDATE())),
('Scientific Calculator Bundle', 600.00, 'Stationery', 'Advanced scientific calculator with case and manual', 1, 1, 'https://m.media-amazon.com/images/I/71YyK1Q4RqL._AC_SL1500_.jpg', DATEADD(DAY, 2, GETDATE()));

-- Insert some inactive products for testing
INSERT INTO [dbo].[Product] ([name], [price], [category], [description], [active], [quatity], [icon], [dateBid])
VALUES 
('Old Edition Textbook', 300.00, 'Textbook', 'Previous edition textbook (inactive product)', 0, 5, 'https://via.placeholder.com/300x200?text=Out+of+Stock', '2000-01-01'),
('Broken Headphones', 100.00, 'Electronics', 'Headphones for parts (inactive)', 0, 2, 'https://via.placeholder.com/300x200?text=Inactive', '2000-01-01');

-- Insert sample users
INSERT INTO [dbo].[User] ([name], [email], [password])
VALUES 
('John Student', 'john.student@university.ac.za', 'password123'),
('Sarah Smith', 'sarah.smith@university.ac.za', 'securepass'),
('Mike Johnson', 'mike.johnson@university.ac.za', 'mikepass'),
('Admin User', 'admin@campussentials.com', 'admin123');

-- Insert sample invoices
INSERT INTO [dbo].[Invoice] ([date], [totalPrice], [userId])
VALUES 
(GETDATE(), 1689.98, 1),
(DATEADD(DAY, -1, GETDATE()), 449.99, 2),
(DATEADD(DAY, -3, GETDATE()), 799.99, 1);

-- Insert sample invoice lines
INSERT INTO [dbo].[InvoiceLine] ([Id], [invoiceId], [productId], [quantity], [price])
VALUES 
(1, 1, 1, 1, 889.99),
(2, 1, 3, 1, 799.99),
(3, 2, 4, 1, 449.99),
(4, 3, 3, 1, 799.99);
ALTER TABLE Product ADD userId INT NULL;
ALTER TABLE Product ADD CONSTRAINT FK_Product_User FOREIGN KEY (userId) REFERENCES [User](Id);