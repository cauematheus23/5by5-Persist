use Radar
CREATE TABLE RadarInfo (
    id INT IDENTITY(1,1) PRIMARY KEY,
    concessionaria VARCHAR(255),
    ano_do_pnv_snv VARCHAR(50),
    tipo_de_radar VARCHAR(50),
    rodovia VARCHAR(50),
    uf CHAR(2),
    km_m VARCHAR(50),
    municipio VARCHAR(255),
    tipo_pista VARCHAR(50),
    sentido VARCHAR(50),
    situacao VARCHAR(50),
    data_da_inativacao VARCHAR(255),
    latitude VARCHAR(50),
    longitude VARCHAR(50),
    velocidade_leve VARCHAR(50)
);
