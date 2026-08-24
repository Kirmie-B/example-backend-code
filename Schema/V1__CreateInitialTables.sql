DO $$
BEGIN
	IF EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = 'plant_type') THEN
		RAISE NOTICE 'The plant_type table already exists. Skipping V1_CreateInitialTables.sql migration.';
	ELSE
		-- Create the table for plant sunlight needs and insert the initial values.
		CREATE TABLE sunlight_need (
			id INT PRIMARY KEY,
			name TEXT NOT NULL UNIQUE,
			description TEXT NOT NULL,
			created TIMESTAMP NOT NULL DEFAULT NOW(),
			updated TIMESTAMP NOT NULL DEFAULT NOW()
		);

		COMMENT ON TABLE sunlight_need IS 'Table to store the different amount of sunlight needs of plants.';

		COMMENT ON COLUMN sunlight_need.id IS 'Primary key for the sunlight_need table.';
		COMMENT ON COLUMN sunlight_need.name IS 'The display name of the sunlight need.';
		COMMENT ON COLUMN sunlight_need.description IS 'Full description of the sunlight need.';
		COMMENT ON COLUMN sunlight_need.created IS 'UTC timestamp of when the row was created.';
		COMMENT ON COLUMN sunlight_need.updated IS 'UTC timestamp of when the row was last updated.';

		INSERT INTO sunlight_need (id, name, description) VALUES
			(1, 'Full Sun', 'Requires at least 6 hours of direct sunlight per day.'),
			(2, 'Partial Sun', 'Requires at least 3-6 hours of direct sunlight per day.'),
			(3, 'Partial Shade', 'Requires 2 hours of direct sun or shaded sun for at least half of the day.'),
			(4, 'Full Shade', 'Less than 1 hour of direct sunlight per day, prefers filtered light or shade.');

		-- Create the table for plant water needs and insert the initial values.
		CREATE TABLE water_need (
			id INT PRIMARY KEY,
			name TEXT NOT NULL UNIQUE,
			description TEXT NOT NULL,
			created TIMESTAMP NOT NULL DEFAULT NOW(),
			updated TIMESTAMP NOT NULL DEFAULT NOW()
		);

		COMMENT ON TABLE water_need IS 'Table to store the different amount of water needs of plants.';

		COMMENT ON COLUMN water_need.id IS 'Primary key for the water_need table.';
		COMMENT ON COLUMN water_need.name IS 'The display name of the water need.';
		COMMENT ON COLUMN water_need.description IS 'Full description of the water need.';
		COMMENT ON COLUMN water_need.created IS 'UTC timestamp of when the row was created.';
		COMMENT ON COLUMN water_need.updated IS 'UTC timestamp of when the row was last updated.';

		INSERT INTO water_need (id, name, description) VALUES
			(1, 'Low', 'Requires minimal watering. Drough-tolerant.'),
			(2, 'Medium', 'Requires regular watering. Not drought-tolerant.'),
			(3, 'High', 'Requires frequent watering. Needs consistently moist soil.');
		
		-- Create the table for plant families and insert the initial values.
		CREATE TABLE plant_family (
			id INT PRIMARY KEY,
			name TEXT NOT NULL UNIQUE,
			description TEXT NOT NULL,
			created TIMESTAMP NOT NULL DEFAULT NOW(),
			updated TIMESTAMP NOT NULL DEFAULT NOW()
		);

		COMMENT ON TABLE plant_family IS 'Table to store the different types of plant families.';

		COMMENT ON COLUMN plant_family.id IS 'Primary key for the plant_family table.';
		COMMENT ON COLUMN plant_family.name IS 'The family name of a plant''s scientific classification.';
		COMMENT ON COLUMN plant_family.description IS 'Basic description of the plant family with examples.';
		COMMENT ON COLUMN plant_family.created IS 'UTC timestamp of when the row was created.';
		COMMENT ON COLUMN plant_family.updated IS 'UTC timestamp of when the row was last updated.';
		
		INSERT INTO plant_family (id, name, description) VALUES
			(1, 'Asteraceae', 'Asteraceae, also known as the daisy family, is a large and widespread family of flowering plants. Examples include sunflowers, daisies, and chrysanthemums.'),
			(2, 'Fabaceae', 'Fabaceae, also known as the legume family, includes plants that produce pods with seeds inside. Examples include beans, peas, and lentils.'),
			(3, 'Rosaceae', 'Rosaceae, or the rose family, is a diverse family of plants that includes many fruit-bearing species. Examples include roses, apples, cherries, and strawberries.'),
			(4, 'Lamiaceae', 'Lamiaceae, also known as the mint family, is a family of aromatic plants. Examples include mint, basil, rosemary, and lavender.'),
			(5, 'Poaceae', 'Poaceae, or the grass family, includes important cereal crops and grasses. Examples include wheat, rice, corn (maize), and bamboo.'),
			(6, 'Solanaceae', 'Solanaceae, also known as the nightshade family, includes many important food crops. Examples include tomatoes, potatoes, eggplants, and peppers.'),
			(7, 'Apiaceae', 'Apiaceae, or the carrot family, is a family of mostly aromatic plants. Examples include carrots, celery, parsley, and dill.'),
			(8, 'Brassicaceae', 'Brassicaceae, also known as the mustard family, includes many vegetables and oilseed crops. Examples include cabbage, broccoli, cauliflower, and mustard.'),
			(9, 'Cactaceae', 'Cactaceae is the cactus family, consisting of succulent plants adapted to arid environments. Examples include saguaro cactus and prickly pear cactus.'),
			(10, 'Orchidaceae', 'Orchidaceae is the orchid family, one of the largest families of flowering plants. Examples include Phalaenopsis orchids and Cattleya orchids.'),
			(11, 'Bromeliaceae', 'Bromeliaceae is the bromeliad family, which includes many tropical plants. Examples include pineapples and Spanish moss.'),
			(12, 'Euphorbiaceae', 'Euphorbiaceae, or the spurge family, is a large family of flowering plants. Examples include poinsettias and rubber trees.'),
			(13, 'Malvaceae', 'Malvaceae, or the mallow family, includes many flowering plants. Examples include hibiscus, cotton, and okra.'),
			(14, 'Ranunculaceae', 'Ranunculaceae, or the buttercup family, is a family of mostly herbaceous plants. Examples include buttercups and delphiniums.'),
			(15, 'Caryophyllaceae', 'Caryophyllaceae, or the pink family, includes many herbaceous plants. Examples include carnations and chickweeds.'),
			(16, 'Iridaceae', 'Iridaceae, or the iris family, is a family of flowering plants. Examples include irises and crocuses.'),
			(17, 'Amaryllidaceae', 'Amaryllidaceae is the amaryllis family, which includes many bulbous plants. Examples include daffodils and snowdrops.'),
			(18, 'Arecaceae', 'Arecaceae, or the palm family, includes many tropical and subtropical plants. Examples include coconut palms and date palms.'),
			(19, 'Zingiberaceae', 'Zingiberaceae, or the ginger family, includes many aromatic plants. Examples include ginger and turmeric.'),
			(20, 'Gesneriaceae', 'Gesneriaceae is the gesneriad family, which includes many ornamental plants. Examples include African violets and gloxinias.'),
			(21, 'Bignoniaceae', 'Bignoniaceae is the trumpet vine family, which includes many flowering plants. Examples include trumpet vines and jacarandas.'),
			(22, 'Acanthaceae', 'Acanthaceae is the acanthus family, which includes many tropical plants. Examples include shrimp plants and bear''s breeches.'),
			(23, 'Apocynaceae', 'Apocynaceae, or the dogbane family, includes many flowering plants. Examples include periwinkles and oleanders.'),
			(24, 'Asparagaceae', 'Asparagaceae is the asparagus family, which includes many ornamental and edible plants. Examples include asparagus and agave.'),
			(25, 'Cucurbitaceae', 'Cucurbitaceae, or the gourd family, includes many edible plants. Examples include cucumbers, melons, and pumpkins.'),
			(26, 'Liliaceae', 'Liliaceae, or the lily family, includes many flowering plants. Examples include true lilies and tulips.'),
			(27, 'Moraceae', 'Moraceae, or the mulberry family, includes many trees and shrubs. Examples include figs and mulberries.'),
			(28, 'Rutaceae', 'Rutaceae, or the rue family, includes many aromatic plants. Examples include citrus fruits and rue.'),
			(29, 'Vitaceae', 'Vitaceae is the grape family, which includes many climbing plants. Examples include grapes and Virginia creeper.'),
			(30, 'Oleaceae', 'Oleaceae is the olive family, which includes many trees and shrubs. Examples include olives and lilacs.');

		-- Create the table for the different USDA hardiness zones and insert the initial values.
		CREATE TABLE hardiness_zone (
			id INT PRIMARY KEY,
			name TEXT NOT NULL UNIQUE,
			description TEXT NOT NULL,
			created TIMESTAMP NOT NULL DEFAULT NOW(),
			updated TIMESTAMP NOT NULL DEFAULT NOW()
		);

		COMMENT ON TABLE hardiness_zone IS 'Table to store the different USDA hardiness zones.';

		COMMENT ON COLUMN hardiness_zone.id IS 'Primary key for the hardiness_zone table.';
		COMMENT ON COLUMN hardiness_zone.name IS 'The display name of the hardiness zone.';
		COMMENT ON COLUMN hardiness_zone.description IS 'Full description of the hardiness zone with temperatures in Fahrenheit and Celsius.';
		COMMENT ON COLUMN hardiness_zone.created IS 'UTC timestamp of when the row was created.';
		COMMENT ON COLUMN hardiness_zone.updated IS 'UTC timestamp of when the row was last updated.';

		INSERT INTO hardiness_zone (id, name, description) VALUES
			(1, '1a', 'Zone 1a: -60 to -55 °F (-51.1 to -48.3 °C)'),
			(2, '1b', 'Zone 1b: -55 to -50 °F (-48.3 to -45.6 °C)'),
			(3, '2a', 'Zone 2a: -50 to -45 °F (-45.6 to -42.8 °C)'),
			(4, '2b', 'Zone 2b: -45 to -40 °F (-42.8 to -40 °C)'),
			(5, '3a', 'Zone 3a: -40 to -35 °F (-40 to -37.2 °C)'),
			(6, '3b', 'Zone 3b: -35 to -30 °F (-37.2 to -34.4 °C)'),
			(7, '4a', 'Zone 4a: -30 to -25 °F (-34.4 to -31.7 °C)'),
			(8, '4b', 'Zone 4b: -25 to -20 °F (-31.7 to -28.9 °C)'),
			(9, '5a', 'Zone 5a: -20 to -15 °F (-28.9 to -26.1 °C)'),
			(10, '5b', 'Zone 5b: -15 to -10 °F (-26.1 to -23.3 °C)'),
			(11, '6a', '-10 to -5 °F (-23.3 to -20.6 °C)'),
			(12, '6b', '-5 to 0 °F (-20.6 to -17.8 °C)'),
			(13, '7a', '0 to 5 °F (-17.8 to -15 °C)'),
			(14, '7b', '5 to 10 °F (-15 to -12.2 °C)'),
			(15, '8a', '10 to 15 °F (-12.2 to -9.4 °C)'),
			(16, '8b', '15 to 20 °F (-9.4 to -6.7 °C)'),
			(17, '9a', '20 to 25 °F (-6.7 to -3.9 °C)'),
			(18, '9b', '25 to 30 °F (-3.9 to -1.1 °C)'),
			(19, '10a', '30 to 35 °F (-1.1 to 1.7 °C)'),
			(20, '10b', '35 to 40 °F (1.7 to 4.4 °C)'),
			(21, '11a', '40 to 45 °F (4.4 to 7.2 °C)'),
			(22, '11b', '45 to 50 °F (7.2 to 10 °C)'),
			(23, '12a', '50 to 55 °F (10 to 12.8 °C)'),
			(24, '12b', '55 to 60 °F (12.8 to 15.6 °C)'),
			(25, '13a', '60 to 65 °F (15.6 to 18.3 °C)'),
			(26, '13b', '65 to 70 °F (18.3 to 21.1 °C)');

		-- Create the table for different plant types and insert the initial values.
		CREATE TABLE plant_type (
			id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
			name TEXT NOT NULL UNIQUE,
			description TEXT NOT NULL,
			created TIMESTAMP NOT NULL DEFAULT NOW(),
			updated TIMESTAMP NOT NULL DEFAULT NOW(),
			sunlight_need_id_preferred INT NOT NULL,
			sunlight_need_id_tolerated INT,
			water_need_id INT NOT NULL,
			soil_ph_min NUMERIC NOT NULL,
			soil_ph_max NUMERIC NOT NULL,
			plant_family_id INT NOT NULL,
			is_perennial BOOLEAN NOT NULL,
			hardiness_zone_id_min INT NOT NULL,
			hardiness_zone_id_max INT NOT NULL,
			CONSTRAINT fk_plant_type__sunlight_need_id_preferred FOREIGN KEY(sunlight_need_id_preferred) REFERENCES sunlight_need(id),
			CONSTRAINT fk_plant_type__sunlight_need_id_tolderated FOREIGN KEY(sunlight_need_id_tolerated) REFERENCES sunlight_need(id),
			CONSTRAINT fk_plant_type__water_need_id FOREIGN KEY(water_need_id) REFERENCES water_need(id),
			CONSTRAINT fk_plant_type__plant_family_id FOREIGN KEY(plant_family_id) REFERENCES plant_family(id),
			CONSTRAINT fk_plant_type__hardiness_zone_id_min FOREIGN KEY(hardiness_zone_id_min) REFERENCES hardiness_zone(id),
			CONSTRAINT fk_plant_type__hardiness_zone_id_max FOREIGN KEY(hardiness_zone_id_max) REFERENCES hardiness_zone(id)
		);

		COMMENT ON TABLE plant_type IS 'Table to store the different types of plants.';

		COMMENT ON COLUMN plant_type.id IS 'Primary key for the plant_type table.';
		COMMENT ON COLUMN plant_type.name IS 'The display name of the plant type.';
		COMMENT ON COLUMN plant_type.description IS 'A brief description of the plan type.';
		COMMENT ON COLUMN plant_type.created IS 'UTC timestamp of when the row was created.';
		COMMENT ON COLUMN plant_type.updated IS 'UTC timestamp of when the row was last updated.';
		COMMENT ON COLUMN plant_type.sunlight_need_id_preferred IS 
			'Foreign key to the sunlight_need table indicating the preferred sunlight for the plant type.';
		COMMENT ON COLUMN plant_type.sunlight_need_id_tolerated IS 
			'Foreign key to the sunlight_need table indicating the tolerated sunlight for the plant type.';
		COMMENT ON COLUMN plant_type.water_need_id IS 'Foreign key to the water_need table indicating the water needs for the plant type.';
		COMMENT ON COLUMN plant_type.soil_ph_min IS 'The minimum soil pH that the plant type requires.';
		COMMENT ON COLUMN plant_type.soil_ph_max IS 'The maximum soil pH that the plant type requires.';
		COMMENT ON COLUMN plant_type.plant_family_id IS 
			'Foreign key to the plant_family table indicating the family that the plant type belongs to.';
		COMMENT ON COLUMN plant_type.is_perennial IS 'Boolean indicating if the plant type is a perennial (true) or annual (false) in the continental United States.';
		COMMENT ON COLUMN plant_type.hardiness_zone_id_min IS 
			'Foreign key to the hardiness_zone table indicating the minimum hardiness zone for the plant type.';
		COMMENT ON COLUMN plant_type.hardiness_zone_id_max IS 
			'Foreign key to the hardiness_zone table indicating the maximum hardiness zone for the plant type.';

		INSERT INTO plant_type (name, description, sunlight_need_id_preferred, sunlight_need_id_tolerated, water_need_id, soil_ph_min, 
			soil_ph_max, plant_family_id, is_perennial, hardiness_zone_id_min, hardiness_zone_id_max) VALUES
			('Jalapeno', 'A medium-sized chili pepper with a Scoville heat range of 2,500 to 8,000.', 1, null, 2, 6.0, 7.0, 6, false, 9, 22),
			('Zuchinni', 'A summer squash that is typically dark green.', 1, null, 2, 6.0, 7.0, 25, false, 5, 22),
			('Carrot', 'A root vegetable that is typically orange in color.', 1, 2, 2, 6.0, 6.8, 8, false, 5, 20),
			('Poblano', 'A mild chili pepper that is typically dark green or red.', 1, null, 2, 6.0, 7.0, 6, false, 3, 20),
			('Tomato', 'A red or yellow fruit that is typically eaten as a vegetable.', 1, null, 2, 6.0, 7.0, 6, false, 3, 22),
			('Basil', 'A leafy green herb that is typically used in cooking.', 1, null, 1, 6.0, 7.5, 4, false, 7, 22),
			('Rosemary', 'A woody, perennial herb with fragrant evergreen needle-like leaves.', 1, null, 1, 6.0, 7.8, 4, true, 7, 20),
			('Mint', 'A fragrant herb that is typically used in cooking and beverages.', 1, 2, 1, 6.0, 7.0, 4, true, 5, 18),
			('Cucumber', 'A long, green vegetable that is typically eaten raw or pickled.', 1, null, 3, 6.0, 7.0, 25, false, 5, 22),
			('Asparagus', 'A perennial vegetable that is typically eaten as a spring vegetable.', 1, null, 2, 6.5, 7.0, 24, true, 5, 16),
			('Broccoli', 'A green vegetable that is typically eaten cooked or raw.', 1, null, 2, 6.0, 7.0, 8, false, 3, 22),
			('Cauliflower', 'A white vegetable that is typically eaten cooked or raw.', 1, null, 2, 6.0, 7.0, 8, false, 3, 22),
			('Bell Pepper', 'A sweet pepper that is typically eaten raw or cooked.', 1, null, 2, 6.0, 6.8, 6, false, 5, 22),
			('Key Lime', 'A small, green citrus fruit that is typically used in cooking and beverages.', 1, null, 2, 6.0, 7.0, 28, true, 17, 22),
			('Eggplant', 'A purple vegetable that is typically eaten cooked.', 1, null, 3, 5.5, 6.8, 6, false, 17, 24),
			('Blueberry', 'A small, blue fruit that is typically eaten raw or used in cooking and baking.', 1, null, 2, 4.5, 5.5, 28, true, 5, 20),
			('Strawberry', 'A red fruit that is typically eaten raw or used in cooking and baking.', 1, null, 2, 5.5, 6.8, 8, false, 5, 18),
			('Tomatillo', 'A small, green fruit that is typically used in cooking and sauces.', 1, null, 2, 6.0, 6.8, 6, false, 9, 22),
			('Potato', 'A starchy, tuberous vegetable that is typically eaten cooked.', 1, null, 2, 5.0, 6.5, 6, false, 5, 20),
			('Pumpkin', 'A large, typically orange fruit use in cooking and baking.', 1, null, 3, 6.0, 6.8, 25, false, 5, 22),
			('Watermelon', 'A large, typically green fruit that is usually eaten raw.', 1, null, 2, 6.0, 6.8, 25, false, 5, 22),
			('Marigold', 'A bright, usually orange or yellow flower that is used in gardens and landscaping.', 1, null, 2, 6.0, 7.0, 15, false, 3, 22),
			('Sugar Snap Pea', 'A sweet pea that is typically eaten raw or cooked.', 1, null, 2, 6.0, 7.0, 2, false, 5, 22),
			('Soybean', 'A legume that is typically used in cooking and food production.', 1, null, 2, 6.0, 7.0, 2, false, 3, 22),
			('Garlic', 'A bulbous plant that is typically used in cooking and food production.', 1, null, 2, 6.0, 7.0, 24, false, 7, 18),
			('Onion', 'A bulbous plant that is typically used in cooking and food production.', 1, null, 2, 6.0, 6.8, 24, false, 3, 18),
			('Chives', 'A herb that is typically used in cooking and food production.', 1, 2, 2, 6.0, 7.0, 24, true, 5, 18),
			('Hibiscus', 'A tropical plant that is typically used in gardens and landscaping.', 1, null, 3, 6.0, 7.0, 13, true, 7, 24);
	END IF;
END $$;