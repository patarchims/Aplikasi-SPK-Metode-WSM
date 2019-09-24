-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 24 Sep 2019 pada 15.33
-- Versi server: 10.3.16-MariaDB
-- Versi PHP: 7.1.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `wsm_db`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_alternatif`
--

CREATE TABLE `tb_alternatif` (
  `id_alternatif` varchar(8) NOT NULL,
  `nik` varchar(16) NOT NULL,
  `nama` varchar(150) NOT NULL,
  `jenis_kelamin` varchar(20) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `no_hp` varchar(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tb_alternatif`
--

INSERT INTO `tb_alternatif` (`id_alternatif`, `nik`, `nama`, `jenis_kelamin`, `alamat`, `no_hp`) VALUES
('A1', '1272061506940001', 'Fahri Pane', 'Laki-Laki', 'Jalan Pane', '081264122314'),
('A2', '1282061506940002', 'Muhammad Hafiz', 'Laki-Laki', 'Jalan Jawa No. 125 Pematangsiantar', '0811164126453'),
('A3', '1272061506940003', 'Farid Abdilah', 'Laki-Laki', 'Jalan Kartini No. 25 Pematangsiantar', '0811312546'),
('A4', '1272051509940001', 'Dedi Andika', 'Laki-Laki', 'Jalan Medan Km 18 Pematangsiantar', '081164114611'),
('A5', 'Arifin Lubis', 'Arifin Lubis', 'Laki-Laki', 'Jalan Singa Mangaraja IV No. 188 Pematangsiantar', '082088204620');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_datanilai`
--

CREATE TABLE `tb_datanilai` (
  `id` int(11) NOT NULL,
  `id_alternatif` varchar(8) NOT NULL,
  `id_subkriteria` varchar(8) NOT NULL,
  `nilai` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tb_datanilai`
--

INSERT INTO `tb_datanilai` (`id`, `id_alternatif`, `id_subkriteria`, `nilai`) VALUES
(39, 'A1', 'SK1', 95),
(40, 'A1', 'SK2', 90),
(41, 'A1', 'SK3', 90),
(42, 'A1', 'SK4', 100),
(43, 'A1', 'SK5', 90),
(44, 'A1', 'SK6', 90),
(45, 'A1', 'SK7', 90),
(46, 'A1', 'SK8', 100),
(47, 'A1', 'SK9', 95),
(48, 'A1', 'SK10', 90),
(49, 'A2', 'SK1', 100),
(50, 'A2', 'SK2', 95),
(51, 'A2', 'SK3', 100),
(52, 'A2', 'SK4', 80),
(53, 'A2', 'SK5', 90),
(54, 'A2', 'SK6', 90),
(55, 'A2', 'SK7', 90),
(56, 'A2', 'SK8', 80),
(57, 'A2', 'SK9', 80),
(58, 'A2', 'SK10', 80),
(59, 'A3', 'SK1', 95),
(60, 'A3', 'SK2', 90),
(61, 'A3', 'SK3', 85),
(62, 'A3', 'SK4', 80),
(63, 'A3', 'SK5', 85),
(64, 'A3', 'SK6', 80),
(65, 'A3', 'SK7', 90),
(66, 'A3', 'SK8', 95),
(67, 'A3', 'SK9', 90),
(68, 'A3', 'SK10', 90),
(69, 'A4', 'SK1', 95),
(70, 'A4', 'SK2', 90),
(71, 'A4', 'SK3', 90),
(72, 'A4', 'SK4', 100),
(73, 'A4', 'SK5', 100),
(74, 'A4', 'SK6', 95),
(75, 'A4', 'SK7', 90),
(76, 'A4', 'SK8', 100),
(77, 'A4', 'SK9', 95),
(78, 'A4', 'SK10', 100),
(79, 'A5', 'SK1', 90),
(80, 'A5', 'SK2', 90),
(81, 'A5', 'SK3', 90),
(82, 'A5', 'SK4', 90),
(83, 'A5', 'SK5', 100),
(84, 'A5', 'SK6', 100),
(85, 'A5', 'SK7', 100),
(86, 'A5', 'SK8', 80),
(87, 'A5', 'SK9', 90),
(88, 'A5', 'SK10', 95);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_kriteria`
--

CREATE TABLE `tb_kriteria` (
  `id_kriteria` varchar(8) NOT NULL,
  `nama_kriteria` varchar(100) NOT NULL,
  `bobot` int(11) NOT NULL,
  `normalisasi` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tb_kriteria`
--

INSERT INTO `tb_kriteria` (`id_kriteria`, `nama_kriteria`, `bobot`, `normalisasi`) VALUES
('C1', 'Faktor Estimasi', 45, 0.45),
('C2', 'Faktor Loyality', 15, 0.15),
('C3', 'Faktor Penampilan diri', 15, 0.15),
('C4', 'Faktor Attitude', 25, 0.25);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_penilaian`
--

CREATE TABLE `tb_penilaian` (
  `id` int(11) NOT NULL,
  `id_alternatif` varchar(8) NOT NULL,
  `n1` float NOT NULL,
  `n2` float NOT NULL,
  `n3` float NOT NULL,
  `n4` float NOT NULL,
  `n5` float NOT NULL,
  `n6` float NOT NULL,
  `n7` float NOT NULL,
  `n8` float NOT NULL,
  `n9` float NOT NULL,
  `n10` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

--
-- Dumping data untuk tabel `tb_penilaian`
--

INSERT INTO `tb_penilaian` (`id`, `id_alternatif`, `n1`, `n2`, `n3`, `n4`, `n5`, `n6`, `n7`, `n8`, `n9`, `n10`) VALUES
(1, 'A1', 14.25, 13.5, 13.5, 10, 4.5, 9, 4.5, 10, 4.75, 9),
(2, 'A2', 15, 14.25, 15, 8, 4.5, 9, 4.5, 8, 4, 8),
(3, 'A3', 14.25, 13.5, 12.75, 8, 4.25, 8, 4.5, 9.5, 4.5, 9),
(4, 'A4', 14.25, 13.5, 13.5, 10, 5, 9.5, 4.5, 10, 4.75, 10),
(5, 'A5', 13.5, 13.5, 13.5, 9, 5, 10, 5, 8, 4.5, 9.5);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_subkriteria`
--

CREATE TABLE `tb_subkriteria` (
  `id` int(11) NOT NULL,
  `id_subkriteria` varchar(8) NOT NULL,
  `id_kriteria` varchar(8) NOT NULL,
  `nama_subkriteria` varchar(100) NOT NULL,
  `nilai` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tb_subkriteria`
--

INSERT INTO `tb_subkriteria` (`id`, `id_subkriteria`, `id_kriteria`, `nama_subkriteria`, `nilai`) VALUES
(1, 'SK1', 'C1', 'Perbaikan', 0.15),
(2, 'SK2', 'C1', 'Waktu', 0.15),
(3, 'SK3', 'C1', 'Biaya', 0.15),
(4, 'SK4', 'C2', 'Kepekaan', 0.1),
(5, 'SK5', 'C2', 'Simpati & Empati', 0.05),
(6, 'SK6', 'C3', 'Pakaian Rapih', 0.1),
(7, 'SK7', 'C3', 'Wajah Bersih & Tidak Berjanggut', 0.05),
(8, 'SK8', 'C4', 'Senyum Sapa', 0.1),
(9, 'SK9', 'C4', 'Intonasi Suara', 0.05),
(10, 'SK10', 'C4', 'Tutur Bicara', 0.1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `users`
--

CREATE TABLE `users` (
  `username` varchar(25) NOT NULL,
  `password` varchar(50) NOT NULL,
  `user_type` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `users`
--

INSERT INTO `users` (`username`, `password`, `user_type`) VALUES
('admins', 'YWRtaW5z', 'Administrator');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tb_alternatif`
--
ALTER TABLE `tb_alternatif`
  ADD PRIMARY KEY (`id_alternatif`);

--
-- Indeks untuk tabel `tb_datanilai`
--
ALTER TABLE `tb_datanilai`
  ADD PRIMARY KEY (`id`);

--
-- Indeks untuk tabel `tb_kriteria`
--
ALTER TABLE `tb_kriteria`
  ADD PRIMARY KEY (`id_kriteria`);

--
-- Indeks untuk tabel `tb_penilaian`
--
ALTER TABLE `tb_penilaian`
  ADD PRIMARY KEY (`id`);

--
-- Indeks untuk tabel `tb_subkriteria`
--
ALTER TABLE `tb_subkriteria`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_subkriteria` (`id_subkriteria`) USING BTREE;

--
-- Indeks untuk tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`username`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `tb_datanilai`
--
ALTER TABLE `tb_datanilai`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=89;

--
-- AUTO_INCREMENT untuk tabel `tb_penilaian`
--
ALTER TABLE `tb_penilaian`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT untuk tabel `tb_subkriteria`
--
ALTER TABLE `tb_subkriteria`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
