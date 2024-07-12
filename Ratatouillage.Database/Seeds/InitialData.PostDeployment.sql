-- Cleanup
DELETE FROM [Recipe_Ingredient];
DELETE FROM [Recipe];
DELETE FROM [Ingredient];


-- Ingredients
SET IDENTITY_INSERT [Ingredient] ON;
INSERT INTO [Ingredient] ([Id], [Name])
 VALUES (1, 'Oeuf'),
		(2, 'Sucre'),
		(3, 'Beurre doux'),
		(4, 'Farine'),
		(5, 'Pépites de chocolat'),
		(6, 'Sucre vanillé'),
		(7, 'Levure'),
		(8, 'Sel'),
		(9, 'Eau'),
		(10, 'Beurre demi-sel'),
		(11, 'Sucre en poudre');
SET IDENTITY_INSERT [Ingredient] OFF;


-- Ingredients
SET IDENTITY_INSERT [Recipe] ON;
INSERT INTO [Recipe] ([Id], [Name], [Desc])
 VALUES (1, 'Cookies', 'Découvrez la recette de cookies avec de belles pépites de chocolat, un peu de rêve et d''évasion dans un biscuit tendre qui enchante les enfants, les adolescents et les adultes. Convient aux végétariens.'),
		(2, 'Kouign-amann', 'Un dessert très riche en calories et très apprécié des gourmands.');
SET IDENTITY_INSERT [Recipe] OFF;


-- Recipe_Ingredient
INSERT INTO [Recipe_Ingredient] ([Recipe_Id], [Ingredient_Id], [Quantity])
 VALUES (1, 1, '1 piece'),
        (1, 2, '85 g'),
		(1, 3, '85 g'),
		(1, 4, '150 g'),
		(1, 5, '100 g'),
		(1, 6, '1 sachet'),
		(1, 7, '1 càc'),
		(1, 8, '1/2 càc'),
		(2, 4, '500 g'),
		(2, 7, '17 g'),
		(2, 9, '20 cl'),
		(2, 10, '400 g'),
		(2, 11, '200 g');

