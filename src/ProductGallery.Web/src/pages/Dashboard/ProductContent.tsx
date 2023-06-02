import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import SearchIcon from '@mui/icons-material/Search';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import { Alert, Avatar, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, IconButton, Pagination, Snackbar, Stack, Table, TableBody, TableCell, TableContainer, TableHead, TablePagination, TableRow, Tooltip } from '@mui/material';
import { Product } from '../../models/Product';
import { useEffect, useState } from 'react';
import { deleteProduct, getProducts } from '../../services/ProductService';
import { PagedResponse } from '../../models/Response';
import ProductForm from '../../components/FormModal';

export default function ProductContent() {
    const [open, setOpen] = useState(false);
    const [modalOpen, setModalOpen] = useState(false);

    const [serviceData, setServiceData] = useState<PagedResponse<Product[]>>();
    const [pageIndex, setPageIndex] = useState<number>(0);
    const [pageSize, setPageSize] = useState<number>(10);
    const [filter, setFilter] = useState<string>();

    useEffect(() => {
        getProducts(pageIndex, pageSize).then((res) => setServiceData(res.data));
        console.log(serviceData);
    }, []);

    const handleChangePage = (
        event: React.MouseEvent<HTMLButtonElement> | null,
        newPage: number,
    ) => {
        getProducts(newPage, pageSize, filter).then((res) => setServiceData(res.data));
        setPageIndex(newPage);
    };

    const handleChangeRowsPerPage = (
        event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
    ) => {
        let size = parseInt(event.target.value, 10);
        getProducts(pageIndex, size, filter).then((res) => setServiceData(res.data));
        setPageSize(size);
    };

    const handleFilterInput = (
        event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
    ) => {
        let input = isEmpty(event.target.value) ? undefined : event.target.value;
        getProducts(pageIndex, pageSize, input).then((res) => setServiceData(res.data));
        setFilter(input);
    };

    const handleDeleteRow = (
        productId: string
    ) => {
        deleteProduct(productId)
            .then((res) => {
                setOpen(true);
                serviceData?.data.forEach((item, index) => {
                    if (item.id === productId) serviceData?.data.splice(index, 1);
                });
            })
    };

    const isEmpty = (str: string) => (!str?.length);
    return (
        <Paper sx={{ maxWidth: 936, margin: 'auto', overflow: 'hidden' }}>
            <AppBar
                position="static"
                color="default"
                elevation={0}
                sx={{ borderBottom: '1px solid rgba(0, 0, 0, 0.12)' }}
            >
                <Toolbar>
                    <Grid container spacing={2} alignItems="center">
                        <Grid item>
                            <SearchIcon color="inherit" sx={{ display: 'block' }} />
                        </Grid>

                        <Grid item xs>
                            <TextField
                                fullWidth
                                placeholder="Search by name, description, or category"
                                InputProps={{
                                    disableUnderline: true,
                                    sx: { fontSize: 'default' },
                                }}
                                variant="standard"
                                onChange={handleFilterInput}
                            />
                        </Grid>

                        <Grid item>
                            <Button variant="contained" sx={{ mr: 1 }}
                                onClick={() => setModalOpen(true)}
                            >
                                Add Product
                            </Button>
                        </Grid>
                    </Grid>
                </Toolbar>
            </AppBar>
                <TableContainer component={Paper}>
                    <Table  sx={{ minWidth: 650 }} aria-label="simple table">
                        <TableHead>
                        <TableRow>
                                <TableCell>#</TableCell>
                                <TableCell>Name</TableCell>
                                <TableCell align="right">Description</TableCell>
                                <TableCell align="right">Category</TableCell>
                                <TableCell align="right">Actions</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {serviceData?.data.map((row) => (
                                <TableRow
                                    key={row.name}
                                    sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                >
                                    <TableCell><Avatar
                                        alt="Remy Sharp"
                                        src={row.imageUrl}
                                        sx={{ width: 56, height: 56 }}
                                    /></TableCell>
                                    <TableCell component="th" scope="row">
                                        {row.name}
                                    </TableCell>
                                    <TableCell align="right">{row.description}</TableCell>
                                    <TableCell align="right">{row.category.name}</TableCell>
                                    <TableCell align="right">
                                        <Stack direction="row-reverse" spacing={1}>
                                            <Tooltip title="Edit">
                                                <IconButton aria-label="edit">
                                                    <EditIcon />
                                                </IconButton>
                                            </Tooltip>
                                            <Tooltip title="Delete">
                                                <IconButton aria-label="delete" onClick={() => handleDeleteRow(row.id)}>
                                                    <DeleteIcon />
                                                </IconButton>
                                            </Tooltip>
                                        </Stack>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                <TablePagination
                    component="div"
                    count={serviceData?.totalRecords ?? 0}
                    page={pageIndex}
                    rowsPerPage={pageSize}
                    onPageChange={handleChangePage}
                    onRowsPerPageChange={handleChangeRowsPerPage}
                />
            </TableContainer>

            <Snackbar
                open={open}
                autoHideDuration={6000}
                message="Product Deleted successfull"
                onClose={() => setOpen(false)}
            />

            <Dialog open={modalOpen} onClose={() => setModalOpen(false)}>
                <ProductForm title="Create Product" />
                
            </Dialog>
            
        </Paper>
    );
}