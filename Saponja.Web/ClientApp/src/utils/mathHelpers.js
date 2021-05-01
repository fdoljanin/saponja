export const getNumberOfPages = (numberOfResults) => {
  const RESULTS_PER_PAGE = 3;
  return Math.ceil(numberOfResults / RESULTS_PER_PAGE);
}